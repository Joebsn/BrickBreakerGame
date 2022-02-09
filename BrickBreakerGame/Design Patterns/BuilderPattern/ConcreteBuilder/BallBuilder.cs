using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using System.Drawing;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.ConcreteBuilder
{
    public class BallBuilder : BlockBuilder
    {
        public override void setHeight()
        {
            b.block.Height = 12;
        }
        public override void setWidth()
        {
            b.block.Width = 15;
        }
        public override void setTag()
        {
            b.block.Tag = "Ball";
        }
        public override void setBackColor()
        {
            b.block.BackColor = Color.White;
        }
        public override void setLeft(int i)
        {
            b.block.Left = 150;

        }
        public override void setTop(int i)
        {
            b.block.Top = 280;
        }
    }
}
