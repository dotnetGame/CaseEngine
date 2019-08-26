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
            _entityDataManager = new EntityDataManager();
        }

        public EntityArchetype CreateArchetype(params Type[] types)
        {
            foreach(var t in types)
            {
                if (!t.GetInterfaces().Contains(typeof(IComponent)))
                    throw new ArgumentException("Type does not implement IComponent.");


            }
        }

        public Entity CreateEntity()
        {
            Entity e = new Entity(this);
            e.Archetype = _archetypeManager.AddArchetype(new ComponentTypeList());
            if (e.Archetype.TypeIndex != 0)
            {
                var typeList = _archetypeManager.GetArchetypeTypeList(e.Archetype);
                e.EntityIndex = _entityDataManager.Alloc(typeList);
            }
            return e;
        }

        public void DestroyEntity(Entity entity)
        {
        }

        public void SetComponent(Entity entity, IComponent component)
        {

        }

        public IComponent GetComponent<T>(Entity entity)
        {
            return null;
        }

        public void AddComponent(Entity entity, IComponent component)
        {
            ComponentType componentType = _componentTypeManager.AddComponentType(component);

            ComponentTypeList typeList = (ComponentTypeList)_archetypeManager.GetArchetypeTypeList(entity.Archetype).Clone();

            typeList.AddComponentType(componentType);

            entity.Archetype = _archetypeManager.AddArchetype(typeList);
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
