using NUnit.Framework;

namespace BowlingKata
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
        public void when_rolling_a_gutter_game()
        {
            RollMany(20, 0);

            Assert.That(_game.Score() == 0);
        }

        [Test]
        public void when_rolling_all_ones_game()
        {
            RollMany(20, 1);

            Assert.That(_game.Score() == 20);
        }

        [Test]
        public void when_rolling_one_spare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            Assert.That(_game.Score() == 16);
        }

        [Test]
        public void when_rolling_one_strike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);

            Assert.That(_game.Score() == 24);
        }

        [Test]
        public void when_rolling_a_perfect_game()
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