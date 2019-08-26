using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseEngine
{
    public class EntityDataManager
    {
        public List<EntityArchetype> Archetypes { get; set; }
        
        public List<ArchetypeChunk> ChunkData { get; set; }

        private ArchetypeManager _archetypeManager;

        public EntityDataManager(ArchetypeManager archetypeManager)
        {
            Archetypes = new List<EntityArchetype>();
            ChunkData = new List<ArchetypeChunk>();
            _archetypeManager = archetypeManager;
        }

        public IComponent GetComponent(Type componentType, int chunkIndex, int chunkOffset)
        {
            if (!componentType.GetInterfaces().Contains(typeof(IComponent)))
                throw new ArgumentException("Type does not implement IComponent.");
            var curChunk = ChunkData[chunkIndex];
            var curArchetype = Archetypes[chunkOffset];
            var curArchetypeList = _archetypeManager.GetArchetypeTypeList(curArchetype);
            if (!curArchetypeList.Contains(componentType))
                throw new ArgumentException("This chunk do not contain this component type.");

            return curChunk.GetComponent(chunkOffset, curArchetypeList.IndexOf(componentType));
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
    }
}
