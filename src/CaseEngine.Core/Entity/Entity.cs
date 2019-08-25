using System;
using System.Collections.Generic;
using System.Text;


namespace CaseEngine
{
    public class Entity
    {
        public EntityArchetype Archetype { get; set; }

        public Guid EntityGuid { get; set; }


        public Entity()
        {
            Archetype = new EntityArchetype();
            EntityGuid = new Guid();
        }

        /*
        public event EntityComponentChanged OnComponentAdded;
        public event EntityComponentChanged OnComponentRemoved;
        public event EntityComponentReplaced OnComponentReplaced;
        public event EntityEvent OnEntityReleased;
        public event EntityEvent OnDestroyEntity;
        */
        /*
        private Dictionary<string, IComponent> _components;

        public void AddComponent(IComponent component)
        {
            if (component == null) return;
            var componentName = component.GetType().Name;
            if (_components.ContainsKey(componentName))
                throw new Exception("The entity already has the component");

            _components[componentName] = component;
        }

        public IComponent GetComponent(string name)
        {
            return _components.GetValueOrDefault(name, null);
        }

        public IComponent GetComponent<ComponentType>() where ComponentType : IComponent
        {
            var componentName = typeof(ComponentType).Name;
            return _components.GetValueOrDefault(componentName, null);
        }

        public bool HasComponent(string name)
        {
            return _components.ContainsKey(name);
        }

        public bool HasComponent<ComponentType>() where ComponentType : IComponent
        {
            var componentName = typeof(ComponentType).Name;
            return _components.ContainsKey(componentName);
        }

        public void RemoveComponent(string name)
        {
            _components.Remove(name);
        }

        public void RemoveComponent<ComponentType>() where ComponentType : IComponent
        {
            var componentName = typeof(ComponentType).Name;
            _components.Remove(componentName);
        }

        public void ReplaceComponent(IComponent component)
        {
            if (component == null) return;
            var componentName = component.GetType().Name;

            _components[componentName] = component;
        }
        */
    }
}
