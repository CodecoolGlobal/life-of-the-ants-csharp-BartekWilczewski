using Codecool.LifeOfAnts.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Worker : Ant
    {
        public Worker(Position position, Colony colony) : base(position, colony)
        {
        }

        protected override char Symbol => 'W';

        public override void Act()
        {
            MoveIntoDirection(DirectionExtensions.GetRandomDirection());
        }
    }
}
