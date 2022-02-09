using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.StrategyPattern
{
    public class Player
    {
        public PictureBox _player;
        private IPlayerBehaviour _behaviour;

        public Player()
        {
            this._player = new PictureBox();
            this._player.Height = 17;
            this._player.Width = 120;
            this._player.Tag = "Player";
            this._player.BackColor = Color.White;
            this._player.Left = 140;
            this._player.Top = 340;
            this._behaviour = new InitialBehaviour();
        }

        public void Move()
        {
            _behaviour.Move(ref this._player);
        }

        public void MoveSlower()
        {
            _behaviour.MoveSlower(ref this._player);
        }

        public IPlayerBehaviour behaviour
        {
            get { return _behaviour; }
            set { _behaviour = value; }
        }
    }
}