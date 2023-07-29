using Codecool.LifeOfAnts.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Soldier : Ant
    {
        private Direction _lastStepDirection;

        public Soldier(Position position, Colony colony) : base(position, colony)
        {
            _lastStepDirection = DirectionExtensions.GetRandomDirection();
        }

        protected override char Symbol => 'S';

        public override void Act()
        {
            _lastStepDirection = _lastStepDirection.TurnLeft();
            MoveIntoDirection(_lastStepDirection);
        }
    }
}
