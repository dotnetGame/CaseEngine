using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class ArchetypeChunk
    {
        public const int CHUNK_MAX_BITS = 16 * 1024;
        public byte[] _data;
        public int _entitySize;
        public int _maxCount;
        public int _count;
        public Guid[] _entityGuids;
        public bool[] _enableList;
        public int[] _componentOffsets;

        public ArchetypeChunk(EntityArchetype entityArchetype)
        {
            _data = new byte[CHUNK_MAX_BITS];
            _entitySize = entityArchetype.EntitySize();
            _maxCount = CHUNK_MAX_BITS / _entitySize;
            _count = 0;
            _entityGuids = new Guid[_maxCount];
            _enableList = new bool[_maxCount];
            _enableList.SetValue(false, 0, _maxCount);

            _componentOffsets = new int[entityArchetype.ComponentCount()];
            int curOffset = 0;
            for (int i = 0; i < entityArchetype.ComponentCount(); ++i)
            {
                _componentOffsets[i] = curOffset;
                curOffset += _maxCount * entityArchetype.ComponentSize(i);
            }
        }

        public int Capacity
        {
            get
            {
                return _maxCount;
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
                return _count == _maxCount;
            }
        }
        public bool Empty
        {
            get
            {
                return _count == 0;
            }
        }

        public bool Alloc(Entity entity)
        {
            if (_count >= _maxCount)
                return false;

            _entityGuids[_count] = entity.EntityGuid;
            _enableList[_count] = true;
            _count += 1;

            return true;
        }
        public bool Dealloc(Entity entity)
        {

        }
    }
}
