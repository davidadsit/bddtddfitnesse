using System.Collections.Generic;

namespace BowlingKata
{
    public class Game
    {
        public Game()
        {
            Rolls = new List<int>(21);
        }

        public IList<int> Rolls { get; set; }

        public void Roll(int pins)
        {
            Rolls.Add(pins);
        }

        public int Score()
        {
            int score = 0;
            int currentFrame = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(currentFrame))
                {
                    score += 10;
                    score += Rolls[currentFrame + 1] + Rolls[currentFrame + 2];
                    currentFrame += 1;
                }
                else if (IsSpare(currentFrame))
                {
                    score += Rolls[currentFrame + 2];
                    score += Rolls[currentFrame] + Rolls[currentFrame + 1];
                    currentFrame += 2;
                }
                else
                {
                    score += Rolls[currentFrame] + Rolls[currentFrame + 1];
                    currentFrame += 2;
                    
                }
            }

            return score;
        }

        private bool IsStrike(int currentFrame)
        {
            return Rolls[currentFrame] == 10;
        }

        private bool IsSpare(int currentFrame)
        {
            return Rolls[currentFrame] + Rolls[currentFrame + 1] == 10;
        }
    }
}