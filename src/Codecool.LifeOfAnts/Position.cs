using Codecool.LifeOfAnts.Geometry;
using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Position struct
    /// </summary>
    public struct Position
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets X coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        ///     Gets Y coordinate
        /// </summary>
        public int Y { get; }

        public int DistanceTo(Position other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }

        public static Position operator +(Position left, Position right)
        {
            return new Position(left.X + right.X, left.Y + right.Y);
        }

        public static Position operator -(Position left, Position right)
        {
            return new Position(left.X - right.X, left.Y - right.Y);
        }

        public Position NextInDirection(Direction direction)
        {
            return this + direction.GetNextPosInDirection();
        }

        public Direction GetDirectionTowardsPosition(Position other)
        {
            Position delta = this - other;

            if(Math.Abs(delta.X) > Math.Abs(delta.Y))
                return delta.X >= 0 ? Direction.West : Direction.East;
            return delta.Y >= 0 ? Direction.South : Direction.North;
        }
    }
}
