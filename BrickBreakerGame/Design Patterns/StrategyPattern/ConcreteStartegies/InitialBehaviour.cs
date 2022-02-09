using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class InitialBehaviour : IPlayerBehaviour
    {
        public void MoveSlower(ref PictureBox player)
        { }

        public void Move(ref PictureBox player)
        { }
    }
}
