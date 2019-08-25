using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CaseEngine
{
    public class EntityArchetype
    {
        private string _archetypeString;
        private List<ComponentType> _types;

        public EntityArchetype()
        {
            _archetypeString = "";
            _types = new List<ComponentType>();
        }

        public EntityArchetype(params ComponentType[] types)
        {
            string archetypeString = "";
            foreach(var t in types)
            {
                archetypeString += t.GetName() + "#";
            }
            _archetypeString = archetypeString;
            _types = new List<ComponentType>();
            foreach (var t in types)
            {
                if (!_types.Contains(t))
                    _types.Add(t);
            }
        }

        public List<ComponentType> GetComponentTypes()
        {
            return _types;
        }

        public int EntitySize()
        {
            int ret = 0;
            foreach(var eachComponentType in _types)
            {
                ret += Marshal.SizeOf(eachComponentType.ToType());
            }

            return ret;
        }

        public int ComponentSize(int i)
        {
            return Marshal.SizeOf(_types[i].ToType());
        }

        public int ComponentCount()
        {
            return _types.Count;
        }

        public void AddComponentType(ComponentType componentType)
        {
            if(!HasComponentType(componentType))
                _types.Add(componentType);
        }

        public void RemoveComponentType(ComponentType componentType)
        {
            if (HasComponentType(componentType))
                _types.Remove(componentType);
        }

        public bool HasComponentType(ComponentType componentType)
        {
            return _types.Contains(componentType);
        }
    }
}
