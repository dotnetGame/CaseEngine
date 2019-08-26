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
            System.Console.WriteLine(player.GetComponent<PositionComponent>().x);

            player.SetComponent<PositionComponent>(new PositionComponent { x = 5, y = 5 });
            System.Console.WriteLine(player.HasComponent<PositionComponent>());

            player.RemoveComponent<PositionComponent>();
            System.Console.WriteLine(player.HasComponent<PositionComponent>());

        }
    }
}
