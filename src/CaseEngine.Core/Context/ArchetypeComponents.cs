using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class ArchetypeComponents
    {
        private List<ArchetypeChunk> _chunks;

        public void AllocEntity(Entity entity)
        {
            foreach(var eachChunk in _chunks)
            {
                if (!eachChunk.Full)
                {
                    eachChunk.Alloc(entity);
                    return;
                }
            }

            var newChunk = new ArchetypeChunk();
            newChunk.Alloc(entity);
            _chunks.Add(newChunk);
        }
    }
}
