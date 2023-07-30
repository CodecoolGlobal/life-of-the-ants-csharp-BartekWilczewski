using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts.Geometry
{
    public static class DirectionExtensions
    {
        public static Direction[] AllDirections => Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray();

        public static Position GetNextPosInDirection(this Direction direction) => direction switch
        {
            Direction.North => new Position(0, 1),
            Direction.South => new Position(0, -1),
            Direction.East => new Position(1, 0),
            Direction.West => new Position(-1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        public static Direction GetRandomDirection()
        {
            var i = Program.Random.Next(0, AllDirections.Length);
            return AllDirections[i];
        }

        public static Direction TurnLeft(this Direction direction)
        {
            int index = ((int)direction+3) % AllDirections.Length;
            return AllDirections[index];
        }
    }
}
