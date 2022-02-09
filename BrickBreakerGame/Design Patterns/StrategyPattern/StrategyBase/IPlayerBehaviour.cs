using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase
{
    public interface IPlayerBehaviour
    {
        void Move(ref PictureBox _player);
        void MoveSlower(ref PictureBox player);
    }
}
