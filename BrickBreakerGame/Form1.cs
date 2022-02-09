using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies;
using BrickBreakerGame.Design_Patterns.StrategyPattern.StrategyBase;
using BrickBreakerGame.Design_Patterns.StrategyPattern;
using System.Diagnostics;
using BrickBreakerGame.Design_Patterns.BuilderPattern.Director;
using BrickBreakerGame.Design_Patterns.BuilderPattern.Product;
using BrickBreakerGame.Design_Patterns.BuilderPattern.ConcreteBuilder;
using BrickBreakerGame.Design_Patterns.BuilderPattern.Builder;
using BrickBreakerGame.Design_Patterns.SingletonPattern;

namespace BrickBreakerGame
{
    public partial class BrickBreaker : Form
    {
        int BallX = 8, BallY = 70, numberofremovedbricks = 0, totalnumberofbricks = 15, maxballtop = 400, minballtop = 0, minballleft = 0, maxballright = 400;
        bool IsGameOver, level2 = false, start = false;
        Player p;
        Random rnd = new Random();
        PictureBox[] BlockArray;
        PictureBox Ball;
        Score ScoreValue;
        public BrickBreaker()
        {
            InitializeComponent();
            StartTheGame();
        }

        public void StartTheGame()
        {
            createPlayer();
            CreateBall();
            PlaceBlocks();
            SetupTheGame();
            BrickBreakerTimer.Start();
        }

        public void createPlayer()
        {
            p = new Player();
            this.Controls.Add(p._player);
        }

        public void CreateBall()
        {
            var blockcreator = new BlockCreator(new BallBuilder());
            blockcreator.CreateBlock(0);
            var b = blockcreator.GetBlock();
            Ball = b.block;
            this.Controls.Add(Ball);
        }

        private void BrickBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) start = true;
            if (e.KeyCode == Keys.Left) p.behaviour = new GoLeftBehavior();
            if (e.KeyCode == Keys.Right) p.behaviour = new GoRightBehaviour();
            if (e.KeyCode == Keys.Up) p.behaviour = new GoUpBehaviour();
            if (e.KeyCode == Keys.Down) p.behaviour = new GoDownBehaviour();
        }

        private void BrickBreaker_Load(object sender, EventArgs e)
        {

        }

        private void BrickBreakerTimer_Tick(object sender, EventArgs e)
        {
            if (start)
            {
                if (!level2) p.Move();
                else p.MoveSlower();
                ballCode();
                scoreCode();
            }
        }

        private void BrickBreaker_KeyUp(object sender, KeyEventArgs e)
        {
            if (p.behaviour.GetType() == typeof(GoLeftBehavior) && e.KeyCode == Keys.Left) p.behaviour = new InitialBehaviour();
            if (p.behaviour.GetType() == typeof(GoRightBehaviour) && e.KeyCode == Keys.Right) p.behaviour = new InitialBehaviour();
            if (p.behaviour.GetType() == typeof(GoUpBehaviour) && e.KeyCode == Keys.Up) p.behaviour = new InitialBehaviour();
            if (p.behaviour.GetType() == typeof(GoDownBehaviour) && e.KeyCode == Keys.Down) p.behaviour = new InitialBehaviour();

            if (e.KeyCode == Keys.Enter && IsGameOver == true)
            {
                p.behaviour = new InitialBehaviour();
                RemoveBlocks();
                this.Controls.Remove(p._player);
                this.Controls.Remove(Ball);
                StartTheGame();
            }
        }

        private void PlaceBlocks()
        {
            BlockArray = new PictureBox[totalnumberofbricks];
            for (int i = 0; i < BlockArray.Length; i++)
            {
                BlockCreator blockcreator;

                if (!level2) blockcreator = new BlockCreator(new LargeBlocksBuilder());
                else blockcreator = new BlockCreator(new SmallBlocksBuilder());

                blockcreator.CreateBlock(i);
                var b = blockcreator.GetBlock();
                BlockArray[i] = b.block;
                this.Controls.Add(BlockArray[i]);
            }
        }

        private void SetupTheGame()
        {
            ScoreValue = Score.GetScore();
            createScoreLabel();
            IsGameOver = false;
            ScoreLabel.Text = "Score = " + ScoreValue.ScoreCount;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }

        public void createScoreLabel()
        {
            ScoreLabel = ScoreValue.scorelabel;
            this.Controls.Add(ScoreLabel);
        }

        void ballCode()
        {
            Ball.Left += BallX;
            Ball.Top += BallY;

            if (Ball.Left < minballleft || Ball.Left > maxballright) BallX = -BallX;
            if (Ball.Top < minballtop) BallY = -BallY;

            if (Ball.Bounds.IntersectsWith(p._player.Bounds))
            {
                BallY = rnd.Next(5, 12) * -1;
                if (BallX < 0) BallX = rnd.Next(5, 12) * -1;
                else BallX = rnd.Next(5, 12);
            }

            foreach (Control x in this.Controls)
            {
                if ((x is PictureBox && (string)x.Tag == "Blocks") && Ball.Bounds.IntersectsWith(x.Bounds))
                {
                    numberofremovedbricks++;
                    ScoreValue.ScoreCount += 1;
                    BallY = -BallY;
                    this.Controls.Remove(x);
                }
            }
        }

        void scoreCode()
        {
            ScoreLabel.Text = "Score = " + ScoreValue.ScoreCount;

            if (numberofremovedbricks == totalnumberofbricks)
            {
                numberofremovedbricks = 0;
                GameOver("You Won, Press enter to play again");
                level2 = true;
            }
            if (Ball.Top > maxballtop)
            {
                GameOver("You Lost, Press enter to play again");
                numberofremovedbricks = 0;
                ScoreValue.ScoreCount = 0;
                level2 = false;
            }

        }

        private void GameOver(string message)
        {
            IsGameOver = true;
            start = false;
            BrickBreakerTimer.Stop();
            MessageBox.Show(message);
        }

        private void RemoveBlocks()
        {
            foreach (PictureBox x in BlockArray)
            {
                this.Controls.Remove(x);
            }
        }
    }
}
