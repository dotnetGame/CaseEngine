using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class EntityManager
    {
        private Dictionary<EntityArchetype, ArchetypeComponents> _components;

        public EntityArchetype CreateArchetype(params Type[] componentTypes)
        {
            ComponentType[] types = new ComponentType[componentTypes.Length];
            for (int i = 0; i < componentTypes.Length; ++i)
            {
                types[i] = ComponentType.From(componentTypes[i]);
            }
            return new EntityArchetype(types);
        }

        public EntityArchetype CreateArchetype(params IComponent[] components)
        {
            ComponentType[] types = new ComponentType[components.Length];
            for(int i= 0;i<components.Length;++i)
            {
                types[i] = ComponentType.From(components[i]);
            }
            return new EntityArchetype(types);
        }

        public EntityArchetype CreateArchetype(params ComponentType[] componentTypes)
        {
            return new EntityArchetype(componentTypes);
        }

        public Entity CreateEntity()
        {
            Entity e = new Entity();
            if (_components.ContainsKey(e.Archetype))
            {
                // _components[e.Archetype];
            }
            else
            {
                _components[e.Archetype] = new ArchetypeComponents();

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

        public void AddComponent<T>(Entity entity, IComponent component)
        {
            entity.Archetype.AddComponentType(ComponentType.From(component));

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
