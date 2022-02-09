using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class GoUpBehaviour : IPlayerBehaviour
    {
        public void moveSlower(ref PictureBox player)
        {
            if (player.Top > 200) player.Top = player.Top - 10;
        }

        public void move(ref PictureBox player)
        {
            if (player.Top > 200) player.Top = player.Top - 5;
        }
    }
}

