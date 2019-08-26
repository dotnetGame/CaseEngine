using System;
using System.Collections.Generic;
using System.Text;

namespace CaseEngine
{
    public class Context
    {
        public EntityManager _entityManager;
        public Context()
        {
            _entityManager = new EntityManager();
        }

        public Entity CreateEntity()
        {
            if (_entityManager != null)
                return _entityManager.CreateEntity();
            else
                return null;
        }

        public void AddComponent(Entity entity, IComponent component)
        {
            _entityManager.AddComponent(entity, component);
        }
    }
}
