using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class GoLeftBehavior : IPlayerBehaviour
    {
        internal int moveleft = 20, moveleftslower = 10, minimum = 0;
        public void MoveSlower(ref PictureBox player)
        {
            if (player.Left > (minimum + moveleftslower)) player.Left -= moveleftslower;
        }

        public void Move(ref PictureBox player)
        {
            if (player.Left > (minimum + moveleft)) player.Left -= moveleft;
        }
    }
}
