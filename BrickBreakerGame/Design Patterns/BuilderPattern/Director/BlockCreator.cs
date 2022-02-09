using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using BrickBreakerGame.Design_Patterns.BuilderPattern.Product;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.Director
{
    public class BlockCreator
    {
        private readonly BlockBuilder _builder;

        public BlockCreator(BlockBuilder builder)
        {
            _builder = builder;
        }

        public void createBlock(int i)
        {
            _builder.createNewBlock();
            _builder.setHeight();
            _builder.setWidth();
            _builder.setTag();
            _builder.setBackColor();
            _builder.setLeft(i);
            _builder.setTop(i);
        }

        public Blocks getBlock()
        {
            return _builder.getBlock();
        }
    }
}
