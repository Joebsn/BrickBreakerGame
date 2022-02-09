using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class GoLeftBehavior : IPlayerBehaviour
    {
        internal int moveleft = 20, moveleftslower = 10, minimum = 0;
        public void moveSlower(ref PictureBox player)
        {
            if (player.Left > (minimum + moveleftslower)) player.Left -= moveleftslower;
        }

        public void move(ref PictureBox player)
        {
            if (player.Left > (minimum + moveleft)) player.Left -= moveleft;
        }
    }
}
