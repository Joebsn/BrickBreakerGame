using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.Product
{
    public class Blocks
    {
        public PictureBox block;

        public Blocks()
        {
            block = new PictureBox();
        }
    }
}