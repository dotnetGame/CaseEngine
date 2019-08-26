using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CaseEngine
{
    public struct EntityArchetype : IEquatable<EntityArchetype>
    {
        public int TypeIndex { get; set; }

        public EntityArchetype(int value)
        {
            TypeIndex = value;
        }

        public static implicit operator int(EntityArchetype w)
        {
            return w.TypeIndex;
        }

        public static implicit operator EntityArchetype(int w)
        {
            return new EntityArchetype(w);
        }

        public bool Equals(EntityArchetype other)
        {
            return TypeIndex == other.TypeIndex;
        }
    }
    //public class EntityArchetype
    //{
    //    private List<ComponentType> _types;

    //    public EntityArchetype()
    //    {
    //        _types = new List<ComponentType>();
    //    }

    //    public EntityArchetype(params ComponentType[] types)
    //    {
    //        _types = new List<ComponentType>();
    //        foreach (var t in types)
    //        {
    //            if (!_types.Contains(t))
    //                _types.Add(t);
    //        }

    //        _types.Sort();
    //    }

    //    public List<ComponentType> GetComponentTypes()
    //    {
    //        return _types;
    //    }

    //    public int ComponentCount()
    //    {
    //        return _types.Count;
    //    }

    //    public void AddComponentType(ComponentType componentType)
    //    {
    //        if(!HasComponentType(componentType))
    //        {
    //            _types.Add(componentType);
    //            _types.Sort();
    //        }
    //    }

    //    public void RemoveComponentType(ComponentType componentType)
    //    {
    //        if (HasComponentType(componentType))
    //            _types.Remove(componentType);
    //    }

    //    public bool HasComponentType(ComponentType componentType)
    //    {
    //        return _types.Contains(componentType);
    //    }
    //}
}
