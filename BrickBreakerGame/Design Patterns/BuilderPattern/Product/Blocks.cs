using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.BuilderPattern.Product
{
    public class Blocks
    {
        public PictureBox block;

        public Blocks()
        {
            this.block = new PictureBox();
        }
    }
}