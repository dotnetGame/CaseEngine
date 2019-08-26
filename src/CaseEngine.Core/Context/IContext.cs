using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public interface IContext
    {
        Entity CreateEntity();

        void DestroyEntity(Entity entity);
    }
}
