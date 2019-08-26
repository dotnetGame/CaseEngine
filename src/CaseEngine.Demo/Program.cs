using System;
using CaseEngine;

namespace CaseEngine.Demo
{
    public struct PositionComponent : IComponent
    {
        public int x;
        public int y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Context context = new Context();
            Entity player = context.CreateEntity();
            player.AddComponent(new PositionComponent { x = 0, y = 0 });


        }
    }
}
