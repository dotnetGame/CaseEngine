using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseEngine
{
    public struct EntityIndex
    {
        public int ChunkIndex { get; set; }
        public int ChunkOffset { get; set; }

        public bool IsValid()
        {
            return ChunkIndex != -1 && ChunkOffset != -1;
        }
    }

    public struct EntityInternal
    {
        public EntityIndex EntityIndex { get; set; }

        public EntityArchetype Archetype { get; set; }
    }

    public class EntityDataManager
    {
        // component part
        public List<EntityArchetype> Archetypes { get; set; }
        
        public List<ArchetypeChunk> ChunkData { get; set; }

        // other data
        public List<EntityInternal> EntityInternals { get; set; }

        private ArchetypeManager _archetypeManager;

        public EntityDataManager(ArchetypeManager archetypeManager)
        {
            Archetypes = new List<EntityArchetype>();
            ChunkData = new List<ArchetypeChunk>();
            _archetypeManager = archetypeManager;
        }

        public int CreateEntityInternal()
        {
            var entityInternal = new EntityInternal();
            
            entityInternal.Archetype = _archetypeManager.CreateArchetype(new Type[0]);
            entityInternal.EntityIndex = new EntityIndex { ChunkIndex = -1, ChunkOffset = -1 };
            EntityInternals.Add(entityInternal);
            return EntityInternals.Count - 1;
        }

        public void AddComponent(Entity entity, IComponent component)
        {
            var internalEntity = EntityInternals[entity.EntityId];
            var typeList = _archetypeManager.GetArchetypeTypeList(internalEntity.Archetype);

            // remove old alloc
            if (typeList.Count != 0 && internalEntity.EntityIndex.IsValid())
            {
                Dealloc(internalEntity.EntityIndex);
            }

            // update archetype
            typeList.Add(component.GetType());
            internalEntity.Archetype = _archetypeManager.CreateArchetype(typeList.ToArray());

            // alloc new object
            internalEntity.EntityIndex = Alloc(internalEntity.Archetype);
        }

        public void RemoveComponent<T>(Entity entity)
        {

        }

        public IComponent GetComponent(Type componentType, Entity entity)
        {
            var internalEntity = EntityInternals[entity.EntityId];
            if (!componentType.GetInterfaces().Contains(typeof(IComponent)))
                throw new ArgumentException("Type does not implement IComponent.");
            var curChunk = ChunkData[internalEntity.EntityIndex.ChunkIndex];
            var curArchetype = Archetypes[internalEntity.EntityIndex.ChunkOffset];
            var curArchetypeList = _archetypeManager.GetArchetypeTypeList(curArchetype);
            if (!curArchetypeList.Contains(componentType))
                throw new ArgumentException("This chunk do not contain this component type.");

            return curChunk.GetComponent(internalEntity.EntityIndex.ChunkOffset, curArchetypeList.IndexOf(componentType));
        }

        public IComponent GetComponent<T>(Entity entity)
        {
            var internalEntity = EntityInternals[entity.EntityId];
            if (!typeof(T).GetInterfaces().Contains(typeof(IComponent)))
                throw new ArgumentException("Type does not implement IComponent.");
            var curChunk = ChunkData[internalEntity.EntityIndex.ChunkIndex];
            var curArchetype = Archetypes[internalEntity.EntityIndex.ChunkOffset];
            var curArchetypeList = _archetypeManager.GetArchetypeTypeList(curArchetype);
            if (!curArchetypeList.Contains(typeof(T)))
                throw new ArgumentException("This chunk do not contain this component type.");

            return curChunk.GetComponent(internalEntity.EntityIndex.ChunkOffset, curArchetypeList.IndexOf(typeof(T)));
        }

        public EntityIndex Alloc(EntityArchetype entityArchetype)
        {
            var types = _archetypeManager.GetArchetypeTypeList(entityArchetype);
            int offset = -1;
            for (int i = 0; i<Archetypes.Count;++i)
            {
                if(Archetypes[i].Equals(types) && !ChunkData[i].Full)
                {
                    offset = ChunkData[i].Alloc();
                    return new EntityIndex{ ChunkIndex = i, ChunkOffset = offset};
                }
            }

            Archetypes.Add(entityArchetype);
            ChunkData.Add(new ArchetypeChunk(types));

            offset = ChunkData.Last().Alloc();
            return new EntityIndex { ChunkIndex = ChunkData.Count - 1, ChunkOffset = offset };
        }

        public void Dealloc(EntityIndex entityIndex)
        {
            var curChunk = ChunkData[entityIndex.ChunkIndex];
            var curArchetype = Archetypes[entityIndex.ChunkIndex];
            curChunk.Dealloc(entityIndex.ChunkOffset);
        }
    }
}
