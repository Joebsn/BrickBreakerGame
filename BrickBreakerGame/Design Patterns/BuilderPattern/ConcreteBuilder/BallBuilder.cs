using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.ConcreteBuilder
{
    public class BallBuilder : BlockBuilder
    {
        public override void SetHeight()
        {
            b.block.Height = 12;
        }
        public override void SetWidth()
        {
            b.block.Width = 15;
        }
        public override void SetTag()
        {
            b.block.Tag = "Ball";
        }
        public override void SetBackColor()
        {
            b.block.BackColor = Color.White;
        }
        public override void SetLeft(int i)
        {
            b.block.Left = 150;

        }
        public override void SetTop(int i)
        {
            b.block.Top = 280;
        }
    }
}
