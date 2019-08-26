using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseEngine
{
    public class TypeList : IEquatable<TypeList>
    {
        public List<TypeList> Value { get; set; } = new List<TypeList>();

        public bool Equals(TypeList other)
        {
            if (Value.Count != other.Value.Count)
                return false;
            for (int i = 0; i < Value.Count; ++i)
            {
                if (Value[i].Equals(other.Value[i])) return false;
            }

            return true;
        }
    }

    public class ComponentTypeList : IEquatable<ComponentTypeList>, IEnumerable<ComponentType>, ICloneable
    {
        public List<ComponentType> TypeList { get; set; } = new List<ComponentType>();

        public ComponentTypeList()
        {

        }

        public ComponentTypeList(ComponentType[] list)
        {
            TypeList.InsertRange(0, list);
        }

        public void Add(ComponentType t)
        {
            if (!TypeList.Contains(t))
                TypeList.Add(t);
            TypeList.Sort();
            TypeList = TypeList.Distinct().ToList();
        }

        public bool Equals(ComponentTypeList other)
        {
            if (TypeList.Count != other.TypeList.Count)
                return false;
            for (int i = 0; i< TypeList.Count;++i)
            {
                if (TypeList[i].Equals(other.TypeList[i])) return false;
            }

            return true;
        }

        public object Clone()
        {
            ComponentTypeList newTypeList = new ComponentTypeList { TypeList = TypeList };
            return newTypeList;
        }

        public IEnumerator<ComponentType> GetEnumerator()
        {
            return ((IEnumerable<ComponentType>)TypeList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ComponentType>)TypeList).GetEnumerator();
        }
    }

    public class ArchetypeManager
    {
        private List<Type> _componentTypes;
        private List<ComponentTypeList> _entityArchetypes;
        public ArchetypeManager()
        {
            _componentTypes = new List<Type>();
            _entityArchetypes = new List<ComponentTypeList>();
            _entityArchetypes.Add(new ComponentTypeList());
        }

        public EntityArchetype CreateArchetype(params Type[] types)
        {
            List<ComponentType> componentTypes = new List<ComponentType>();
            foreach (var t in types)
            {
                if (!t.GetInterfaces().Contains(typeof(IComponent)))
                    throw new ArgumentException("Type does not implement IComponent.");

                var idx = -1;
                if (_componentTypes.Contains(t))
                {
                    idx = _componentTypes.IndexOf(t);
                }
                else
                {
                    _componentTypes.Add(t);
                    idx = _componentTypes.Count - 1;
                }
                componentTypes.Add(idx);
            }

            componentTypes.Sort();

            var componentTypeList = new ComponentTypeList { TypeList = componentTypes.Distinct().ToList() };

            if (_entityArchetypes.Contains(componentTypeList))
            {
                return _entityArchetypes.IndexOf(componentTypeList);
            }
            else
            {
                _entityArchetypes.Add(componentTypeList);
                return _entityArchetypes.Count - 1;
            }
        }

        public List<Type> GetArchetypeTypeList(EntityArchetype i)
        {
            var componentTypeList = _entityArchetypes[i];
            return (from eachComponentType in componentTypeList select _componentTypes[eachComponentType]).ToList();
        }

        public int GetArchetypeIndex(ComponentTypeList t)
        {
            return _entityArchetypes.IndexOf(t);
        }

        public bool HasArchetype(int archetypeIndex)
        {
            return archetypeIndex >= 0 && archetypeIndex < _entityArchetypes.Count;
        }

        public bool HasArchetype(ComponentTypeList t)
        {
            return _entityArchetypes.Contains(t);
        }
    }
}
