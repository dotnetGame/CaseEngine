using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public interface IContext
    {
        IEntity CreateEntity();

        void DestroyEntity(IEntity entity);
    }
}
