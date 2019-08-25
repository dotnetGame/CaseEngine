
using CaseEngine;

namespace CaseEngine.Demo
{
    public static class PositionExtension
    {
        public static void AddPosition(this Entity entity, int x, int y)
        {

        }
    }

    public sealed class PositionComponent : IComponent
    {
        public int x;
        public int y;
    }
}
