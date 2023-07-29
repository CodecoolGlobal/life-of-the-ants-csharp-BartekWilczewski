using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        private const int MOOD_TIMER_MIN = 50;
        private const int MOOD_TIMER_MAX = 100;

        private int _goodMoodCountdown;

        public Queen(Position position, Colony colony) : base(position, colony)
        {
            ResetTimer();
        }

        protected override char Symbol => 'Q';

        public bool IsInGoodMood => _goodMoodCountdown == 0;

        public override void Act()
        {
            if(_goodMoodCountdown > 0) { _goodMoodCountdown--; }
        }

        public void Mate()
        {
            ResetTimer();
        }

        private void ResetTimer()
        {
            _goodMoodCountdown = Program.Random.Next(MOOD_TIMER_MIN, MOOD_TIMER_MAX);
        }
    }
}
