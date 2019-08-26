using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public struct ComponentType : IEquatable<ComponentType>
    {
        public int TypeIndex { get; set; }

        public bool Equals(ComponentType other)
        {
            return TypeIndex == other.TypeIndex;
        }
    }
    //public struct ComponentType : IEquatable<ComponentType>
    //{
    //    private Type _componentType;
    //    public ComponentType(Type componentType)
    //    {
    //        _componentType = componentType;
    //    }

    //    public string GetName()
    //    {
    //        return _componentType.Name;
    //    }

    //    public Type ToType()
    //    {
    //        return _componentType;
    //    }

    //    public static ComponentType From(IComponent component)
    //    {
    //        return new ComponentType(component.GetType());
    //    }

    //    public static ComponentType From(Type componentType)
    //    {
    //        return new ComponentType(componentType);
    //    }

    //    public bool Equals(ComponentType other)
    //    {
    //        return _componentType.Equals(other._componentType);
    //    }

    //    public override bool Equals(object o)
    //    {
    //        return _componentType.Equals(o);
    //    }

    //    public override int GetHashCode()
    //    {
    //        return _componentType.GetHashCode();
    //    }

    //    public static bool operator ==(ComponentType a, ComponentType b)
    //    {
    //        return a._componentType == b._componentType;
    //    }

    //    public static bool operator !=(ComponentType a, ComponentType b)
    //    {
    //        return a._componentType != b._componentType;
    //    }
    // }
}
