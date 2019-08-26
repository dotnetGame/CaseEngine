using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class EntityDataManager
    {
        public List<EntityArchetype> Archetypes { get; set; }
        
        public List<ArchetypeChunk> ChunkData { get; set; }

        public EntityDataManager()
        {
            Archetypes = new List<EntityArchetype>();
            ChunkData = new List<ArchetypeChunk>();
        }

        public EntityIndex Alloc(EntityArchetype entityArchetype)
        {
            for(int i = 0; i<Archetypes.Count;++i)
            {
                if(Archetypes[i].Equals(entityArchetype) && !ChunkData[i].Full)
                {
                    int offset = ChunkData[i].Alloc(entityArchetype);
                    return new EntityIndex{ ChunkIndex = i, ChunkOffset = offset};
                }
            }
        }
    }
}
