using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class Context : IContext
    {
        public IEntity CreateEntity()
        {
            throw new NotImplementedException();
        }

        public void DestroyEntity(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
