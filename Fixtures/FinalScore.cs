using System;
using System.Globalization;
using System.Linq;

namespace BowlingKata.Fixtures
{
    public class FinalScore
    {
        private string[] _rolls;

        public void Rolls(string rolls)
        {
            _rolls = rolls.Trim().Split(' ');
        }

        public string Score()
        {
            var game = new Game();
            foreach (int roll in _rolls.Select(x => Convert.ToInt32(x)))
            {
                game.Roll(roll);
            }
            return game.Score().ToString(CultureInfo.CurrentCulture);
        }
    }
}