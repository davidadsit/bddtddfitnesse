using Machine.Specifications;

namespace BowlingKata.BDD
{
    public class With_a_game
    {
        private Establish context = () => { _game = new Game(); };

        protected static void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }

        protected static Game _game;
    }

    public class when_rolling_a_gutter_game : With_a_game
    {
        private Because of = () => RollMany(20, 0);

        private It should_score_zero_for_the_game = () => _game.Score().ShouldEqual(0);
    }

    public class when_rolling_all_ones_game : With_a_game
    {
        private Because of = () => RollMany(20, 1);

        private It should_score_20_for_the_game = () => _game.Score().ShouldEqual(20);
    }

    public class when_rolling_one_spare : With_a_game
    {
        private Because of = () =>
                                 {
                                     RollSpare();
                                     _game.Roll(3);
                                     RollMany(17, 0);
                                 };

        private It should_add_the_value_of_the_next_roll_to_the_spare_frame = () => _game.Score().ShouldEqual(16);

        private static void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
    }

    public class when_rolling_one_strike : With_a_game
    {
        private Because of = () =>
                                 {
                                     RollStrike();
                                     _game.Roll(3);
                                     _game.Roll(4);
                                     RollMany(16, 0);
                                 };

        private It should_add_the_value_of_the_next_two_rolls_to_the_strike_frame = () => _game.Score().ShouldEqual(24);

        private static void RollStrike()
        {
            _game.Roll(10);
        }
    }

    public class when_rolling_a_perfect_game : With_a_game
    {
        private Because of = () => RollMany(12, 10);

        private It should_be_300 = () => _game.Score().ShouldEqual(300);
    }
}