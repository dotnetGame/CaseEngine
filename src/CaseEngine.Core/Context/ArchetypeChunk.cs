using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class ArchetypeChunk
    {
        public const int CHUNK_MAX_ENTITIES = 128;
        public Array[] _data;
        public int _count;
        public bool[] _enableList;

        public ArchetypeChunk(EntityArchetype entityArchetype)
        {
            //_data = new Array[entityArchetype.ComponentCount()];
            //var typeList = entityArchetype.GetComponentTypes();
            //for (int i = 0; i < entityArchetype.ComponentCount(); ++i)
            //{
            //    _data[i] = Array.CreateInstance(typeList[i].ToType(), CHUNK_MAX_ENTITIES);
            //}
            //_count = 0;
            //_enableList = new bool[CHUNK_MAX_ENTITIES];
            //_enableList.SetValue(false, 0, CHUNK_MAX_ENTITIES);
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

        public bool Alloc()
        {
            if (_count >= CHUNK_MAX_ENTITIES)
                return false;

            _enableList[_count] = true;
            _count += 1;

            return true;
        }
        public bool Dealloc(Entity entity)
        {
            return true;
        }
    }
}
