using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern
{
    public class Player
    {
        public PictureBox player;
        private IPlayerBehaviour _behaviour;

        public Player()
        {
            player = new PictureBox();
            player.Height = 17;
            player.Width = 120;
            player.Tag = "Player";
            player.BackColor = Color.White;
            player.Left = 140;
            player.Top = 340;
            _behaviour = new InitialBehaviour();
        }

        public void Move()
        {
            _behaviour.move(ref player);
        }

        public void MoveSlower()
        {
            _behaviour.moveSlower(ref player);
        }

        public IPlayerBehaviour behaviour
        {
            get { return _behaviour; }
            set { _behaviour = value; }
        }
    }
}