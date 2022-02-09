using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.ConcreteBuilder
{
    public class LargeBlocksBuilder : BlockBuilder
    {
        public override void SetHeight()
        {
            b.block.Height = 16;
        }
        public override void SetWidth()
        {
            b.block.Width = 50;
        }
        public override void SetTag()
        {
            b.block.Tag = "Blocks";
        }
        public override void SetBackColor()
        {
            b.block.BackColor = Color.White;
        }
        public override void SetLeft(int i)
        {
            var x = i % 5;
            if (i % 5 != 0) b.block.Left = left + (left + 20) * x;

            else b.block.Left = left;

        }
        public override void SetTop(int i)
        {
            var x = i / 5;
            b.block.Top = top + top * x;
        }
    }
}
