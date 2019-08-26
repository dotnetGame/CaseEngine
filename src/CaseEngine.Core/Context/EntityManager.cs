using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseEngine
{
    public class EntityManager
    {
        private ArchetypeManager _archetypeManager;

        private EntityDataManager _entityDataManager;

        public EntityManager()
        {
            _archetypeManager = new ArchetypeManager();
            _entityDataManager = new EntityDataManager(_archetypeManager);
        }

        public EntityArchetype CreateArchetype(params Type[] types)
        {
            return _archetypeManager.CreateArchetype(types);
        }

        public Entity CreateEntity()
        {
            Entity e = new Entity(this);
            e.Archetype = _archetypeManager.CreateArchetype(new Type[0]);
            if (e.Archetype.TypeIndex != 0)
            {
                var typeList = _archetypeManager.GetArchetypeTypeList(e.Archetype);
                e.EntityIndex = _entityDataManager.Alloc(e.Archetype);
            }
            return e;
        }

        public void DestroyEntity(Entity entity)
        {
        }

        public void SetComponent(Entity entity, IComponent component)
        {

        }

        public T GetComponent<T>(Entity entity)
        {
            return (T)_entityDataManager.GetComponent(typeof(T), entity.EntityIndex.ChunkIndex, entity.EntityIndex.ChunkOffset);
        }

        public void AddComponent(Entity entity, IComponent component)
        {
            var typeList = _archetypeManager.GetArchetypeTypeList(entity.Archetype);

            // remove old alloc
            if (entity.Archetype != 0)
            {
            }

            // update archetype
            typeList.Add(component.GetType());
            entity.Archetype = _archetypeManager.CreateArchetype(typeList.ToArray());

            // alloc new object
            if (entity.Archetype != 0)
            {
                entity.EntityIndex = _entityDataManager.Alloc(entity.Archetype);
            }
        }

        public void RemoveComponent<T>(Entity entity)
        {
        }

        public bool HasComponent<T>(Entity entity)
        {
            return true;
        }
    }
}
