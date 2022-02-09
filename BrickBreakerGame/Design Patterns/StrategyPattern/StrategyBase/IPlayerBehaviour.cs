using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase
{
    public interface IPlayerBehaviour
    {
        void move(ref PictureBox _player);
        void moveSlower(ref PictureBox player);
    }
}
