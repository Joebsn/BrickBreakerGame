using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using BrickBreakerGame.Design_Patterns.BuilderPattern.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.Director
{
    public class BlockCreator
    {
        private readonly BlockBuilder _builder;

        public BlockCreator(BlockBuilder builder)
        {
            _builder = builder;
        }

        public void CreateBlock(int i)
        {
            _builder.CreateNewBlock();
            _builder.SetHeight();
            _builder.SetWidth();
            _builder.SetTag();
            _builder.SetBackColor();
            _builder.SetLeft(i);
            _builder.SetTop(i);
        }

        public Blocks GetBlock()
        {
            return _builder.GetBlock();
        }
    }
}
