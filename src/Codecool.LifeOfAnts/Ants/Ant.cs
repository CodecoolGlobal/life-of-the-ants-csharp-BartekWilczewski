using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position { get; set; }
        protected readonly Colony Colony;
        public abstract char Symbol { get; }

        protected Ant(Position position, Colony colony) 
        { 
            Colony = colony;
            Position = position;
        }

        public abstract void Act();

        protected void MoveIntoDirection(Direction dir)
        {
            var nextPos = Position.NextInDirection(dir);
            if (NotWalkedOutsideOfColony(nextPos))
            {
                Position = nextPos;
            }

        }

        private bool NotWalkedOutsideOfColony(Position pos)
        {
            return pos.X >= 0 && pos.X < Colony.Width && pos.Y >= 0 && pos.Y < Colony.Width;
        }
    }
}
