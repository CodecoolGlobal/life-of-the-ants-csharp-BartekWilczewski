using Codecool.LifeOfAnts.Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public readonly int Width;

        public readonly Queen Queen;

        private readonly List<Ant> _ants;

        private readonly Dictionary<Position, List<Ant>> _colonyMap;

        public Colony(int width)
        {
            Width = width;
            Queen = new Queen(new Position(width/2,width/2), this);
            _ants = new List<Ant>();
            _ants.Add(Queen);
            _colonyMap = new Dictionary<Position, List<Ant>>();
        }

        public void AddAnts(int numWorkers, int numDrones, int numSoldiers)
        {
            for (int i = 0; i < numWorkers; i++)
            {
                _ants.Add(new Worker(GetRandomPositionInColony(), this));
            }

            for (int i = 0; i < numDrones; i++)
            {
                _ants.Add(new Drone(GetRandomPositionInColony(), this));
            }

            for (int i = 0; i < numSoldiers; i++)
            {
                _ants.Add(new Soldier(GetRandomPositionInColony(), this));
            }
        }

        public void Update()
        {
            foreach (var ant in _ants)
            {
                GetAntsAtPoint(ant.Position).Remove(ant);
                ant.Act();
                GetAntsAtPoint(ant.Position).Add(ant);
            }
        }

        public void Display()
        {
            Console.Clear();
            var sb = new StringBuilder();

            for(int y = 0; y < Width; y++)
            {
                for(int x = 0;x<Width;x++)
                {
                    var ants = GetAntsAtPoint(new Position(x, y));
                    var symbol = ants.FirstOrDefault()?.Symbol ?? ' ';
                    sb.Append(symbol);
                }
                sb.AppendLine();
            }

            sb.Append(new string('~',Width));
            Console.WriteLine(sb.ToString());
        }

        private Position GetRandomPositionInColony()
        {
            int x = Program.Random.Next(Width);
            int y = Program.Random.Next(Width);

            return new Position(x, y);
        }

        private List<Ant> GetAntsAtPoint(Position position)
        {
            if(!_colonyMap.ContainsKey(position))
                _colonyMap[position] = new List<Ant>();

            return _colonyMap[position];

        }
    }
}
