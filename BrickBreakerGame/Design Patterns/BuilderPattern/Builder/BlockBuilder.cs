using BrickBreakerGame.Design_Patterns.BuilderPattern.Product;
using System;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.Builder
{
    public abstract class BlockBuilder
    {
        protected Blocks b;
        protected int top = 50, left = 50;
        protected Random rnd;
        public void createNewBlock()
        {
            b = new Blocks();
        }

        public Blocks getBlock()
        {
            return b;
        }

        public abstract void setHeight();
        public abstract void setWidth();
        public abstract void setTag();
        public abstract void setBackColor();
        public abstract void setLeft(int i);
        public abstract void setTop(int i);
    }
}
