using NUnit.Framework;

namespace BowlingKata.TDD
{
    [TestFixture]
    public class BowlingGameTests
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void The_score_for_a_gutter_game_is_0()
        {
            RollMany(20, 0);

            Assert.That(_game.Score() == 0);
        }

        [Test]
        public void The_score_for_all_ones_is_20()
        {
            RollMany(20, 1);

            Assert.That(_game.Score() == 20);
        }

        [Test]
        public void A_spare_adds_the_value_of_the_next_ball()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            Assert.That(_game.Score() == 16);
        }

        [Test]
        public void A_strike_adds_the_value_of_the_next_two_balls()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);

            Assert.That(_game.Score() == 24);
        }

        [Test]
        public void The_score_for_a_perfect_game_is_300()
        {
            RollMany(12, 10);
            Assert.That(_game.Score() == 300);
        }

        private void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}