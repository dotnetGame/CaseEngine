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
            Entity entity = new Entity(this);
            entity.EntityId = _entityDataManager.CreateEntityInternal();
            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
        }

        public void SetComponent(Entity entity, IComponent component)
        {

        }

        public T GetComponent<T>(Entity entity)
        {
            return (T)_entityDataManager.GetComponent(typeof(T), entity);
        }

        public void AddComponent(Entity entity, IComponent component)
        {
            _entityDataManager.AddComponent(entity, component);
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
