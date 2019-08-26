using System;
using System.Collections.Generic;
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

    public class ComponentTypeList : IEquatable<ComponentTypeList>, ICloneable
    {
        public List<ComponentType> TypeList { get; set; } = new List<ComponentType>();

        public void AddComponentType(ComponentType t)
        {
            if (!TypeList.Contains(t))
                TypeList.Add(t);
            TypeList.Sort();
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
    }

    public class ArchetypeManager
    {
        private ComponentTypeManager _componentTypeManager;
        private List<ComponentTypeList> _entityArchetypes;
        public ArchetypeManager()
        {
            _componentTypeManager = new ComponentTypeManager();
            _entityArchetypes = new List<ComponentTypeList>();
            _entityArchetypes.Add(new ComponentTypeList());
        }

        public EntityArchetype CreateArchetype(params Type[] componentTypes)
        {
            foreach (var t in componentTypes)
            {
                if (!_componentTypeManager.HasComponentType(t))
                {
                    _componentTypeManager.AddComponentType(t);
                }
            }

            for (int i = 0; i < _entityArchetypes.Count; ++i)
            {
                if (t.Equals(_entityArchetypes[i]))
                    return new EntityArchetype { TypeIndex = i };
            }

            _entityArchetypes.Add(t);
            return new EntityArchetype { TypeIndex = _entityArchetypes.Count - 1 };
        }

        public ComponentTypeList GetArchetypeTypeList(EntityArchetype i)
        {
            return _entityArchetypes[i.TypeIndex];
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
