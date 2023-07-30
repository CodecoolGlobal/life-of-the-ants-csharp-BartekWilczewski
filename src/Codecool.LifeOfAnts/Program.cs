using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        public static readonly Random Random = new Random();

        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            Colony colony = new Colony(30);
            colony.AddAnts(10, 4, 15);

            do
            {
                colony.Update();
                colony.Display();
            }
            while (Console.ReadLine() != "q");
        }
    }
}
