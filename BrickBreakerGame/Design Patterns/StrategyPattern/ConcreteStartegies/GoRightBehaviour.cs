using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class GoRightBehaviour : IPlayerBehaviour
    {
        internal int moveright = 20, moverightslower = 10, maximum = 320;
        public void moveSlower(ref PictureBox player)
        {
            if (player.Left < (maximum - moverightslower)) player.Left += moverightslower;
        }

        public void move(ref PictureBox player)
        {
            if (player.Left < (maximum - moveright)) player.Left += moveright;
        }

    }
}
