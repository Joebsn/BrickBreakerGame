using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class InitialBehaviour : IPlayerBehaviour
    {
        public void moveSlower(ref PictureBox player)
        { }

        public void move(ref PictureBox player)
        { }
    }
}
