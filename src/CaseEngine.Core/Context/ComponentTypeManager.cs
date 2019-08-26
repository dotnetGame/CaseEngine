using System;
using System.Collections.Generic;

namespace CaseEngine
{
    public class ComponentTypeManager
    {
        private List<Type> _componentTypes;
        public ComponentTypeManager()
        {
            _componentTypes = new List<Type>();
        }

        public ComponentType AddComponentType(IComponent component)
        {
            if (!HasComponentType(component))
            {
                _componentTypes.Add(component.GetType());
                return new ComponentType { TypeIndex= _componentTypes.Count - 1 };
            }
            else
            {
                return GetComponentType(component);
            }
        }

        public ComponentType AddComponentType(Type component)
        {
            if (!HasComponentType(component))
            {
                _componentTypes.Add(component.GetType());
                return new ComponentType { TypeIndex = _componentTypes.Count - 1 };
            }
            else
            {
                return GetComponentType(component);
            }
        }

        public ComponentType GetComponentType(IComponent component)
        {
            return new ComponentType
            {
                TypeIndex = _componentTypes.IndexOf(component.GetType())
            };
        }

        public ComponentType GetComponentType(Type component)
        {
            return new ComponentType
            {
                TypeIndex = _componentTypes.IndexOf(component)
            };
        }

        public Type GetComponentTypeObject(ComponentType component)
        {
            return _componentTypes[component.TypeIndex];
        }

        public bool HasComponentType(int componentTypeIndex)
        {
            return componentTypeIndex >= 0 && componentTypeIndex < _componentTypes.Count;
        }

        public bool HasComponentType(IComponent component)
        {
            return _componentTypes.Contains(component.GetType());
        }

        public bool HasComponentType(Type component)
        {
            return _componentTypes.Contains(component);
        }

        public bool HasComponentType<T>()
        {
            return _componentTypes.Contains(typeof(T));
        }
    }
}