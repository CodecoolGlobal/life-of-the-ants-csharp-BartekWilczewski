using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Drone : Ant
    {
        private const string MATING_START_MSG = "HALLELUJAH";
        private const string MATING_CANNOT_START_MSG = ":(";

        private bool _isMating;
        private int _matingCounter;

        public Drone(Position position, Colony colony) : base(position, colony)
        {
            _matingCounter = 10;
        }

        public override char Symbol => 'D';

        public override void Act()
        {
            if (_isMating)
            {
                ContinueMating(Colony.Queen.Position);
            }
            else if (Position.DistanceTo(Colony.Queen.Position) == 1)
            {
                TryMating();
            }
            else
                MoveIntoDirection(Position.GetDirectionTowardsPosition(Colony.Queen.Position));
        }

        private void ContinueMating(Position queenPos) 
        {
            _matingCounter--;
            if(_matingCounter == 0)
            {
                ResetPosition(queenPos);
                _isMating = false;
                _matingCounter = 10;
            }
        }

        private void ResetPosition(Position queenPos)
        {
            int kickOffDist = Colony.Width / 2;
            int dx = Program.Random.Next(kickOffDist);
            int dy = kickOffDist - dx;

            if(Program.Random.Next(2)  == 0)
            {
                dx *= -1;
            }

            if (Program.Random.Next(2) == 0)
            {
                dy *= -1;
            }

            Position = new Position(queenPos.X + dx, queenPos.Y + dy);
        }

        private void TryMating()
        {
            if( Colony.Queen.IsInGoodMood)
            {
                Console.WriteLine(MATING_START_MSG);
                Colony.Queen.Mate();
                _isMating=true;
            }
            else
            {
                Console.WriteLine(MATING_CANNOT_START_MSG);
                ResetPosition(Colony.Queen.Position);
            }
        }
    }
}
