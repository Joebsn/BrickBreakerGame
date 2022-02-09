using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class GoRightBehaviour : IPlayerBehaviour
    {
        internal int moveright = 20, moverightslower = 10, maximum = 320;
        public void MoveSlower(ref PictureBox player)
        {
            if (player.Left < (maximum - moverightslower)) player.Left += moverightslower;
        }

        public void Move(ref PictureBox player)
        {
            if (player.Left < (maximum - moveright)) player.Left += moveright;
        }

    }
}
