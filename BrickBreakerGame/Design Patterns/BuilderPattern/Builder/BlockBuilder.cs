using BrickBreakerGame.Design_Patterns.BuilderPattern.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.Builder
{
    public abstract class BlockBuilder
    {
        protected Blocks b;
        protected int top = 50, left = 50;
        protected Random rnd;
        public void CreateNewBlock()
        {
            b = new Blocks();
        }

        public Blocks GetBlock()
        {
            return b;
        }

        public abstract void SetHeight();
        public abstract void SetWidth();
        public abstract void SetTag();
        public abstract void SetBackColor();
        public abstract void SetLeft(int i);
        public abstract void SetTop(int i);
    }
}
