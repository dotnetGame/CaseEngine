using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class ArchetypeChunk
    {
        public const int CHUNK_MAX_ENTITIES = 256;
        public IList[] _data;
        public int _count;

        public ArchetypeChunk(List<Type> types)
        {
            _data = new IList[types.Count];
            for (int i = 0; i < types.Count; ++i)
            {
                _data[i] = Array.CreateInstance(types[i], CHUNK_MAX_ENTITIES);
            }
            _count = 0;
        }

        public int Capacity
        {
            get
            {
                return CHUNK_MAX_ENTITIES;
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
        }
        public bool Full
        {
            get
            {
                return _count == CHUNK_MAX_ENTITIES;
            }
        }
        public bool Empty
        {
            get
            {
                return _count == 0;
            }
        }

        public IComponent GetComponent(int entityOffset,int componentIndex)
        {
            return (IComponent)_data[componentIndex][entityOffset];
        }

        public int Alloc()
        {
            if (_count >= CHUNK_MAX_ENTITIES)
                return -1;

            int ret = _count;
            _count += 1;

            return ret;
        }
        public bool Dealloc(int offset)
        {
            return true;
        }
    }
}
