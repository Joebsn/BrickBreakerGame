using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using System.Drawing;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.ConcreteBuilder
{
    public class SmallBlocksBuilder : BlockBuilder
    {
        public override void setHeight()
        {
            b.block.Height = 10;
        }
        public override void setWidth()
        {
            b.block.Width = 20;
        }
        public override void setTag()
        {
            b.block.Tag = "Blocks";
        }
        public override void setBackColor()
        {
            b.block.BackColor = Color.White;
        }
        public override void setLeft(int i)
        {
            var x = i % 5;
            if (i % 5 != 0) b.block.Left = left + (left + 20) * x;

            else b.block.Left = left;

        }
        public override void setTop(int i)
        {
            var x = i / 5;
            b.block.Top = top + top * x;
        }
    }
}
