using System;
using System.Drawing;
using System.Windows.Forms;
using BrickBreakerGame.Design_Patterns.StrategyPattern.ConcreteStartegies;
using BrickBreakerGame.Design_Patterns.StrategyPattern;
using BrickBreakerGame.Design_Patterns.BuilderPattern.Director;
using BrickBreakerGame.Design_Patterns.BuilderPattern.ConcreteBuilder;
using BrickBreakerGame.Design_Patterns.SingletonPattern;

namespace BrickBreakerGame
{
    public partial class brickBreaker : Form
    {
        int ballX = 8, ballY = 70, numberofremovedbricks = 0, totalnumberofbricks = 15, maxballtop = 400, minballtop = 0, minballleft = 0, maxballright = 400;
        bool isGameOver, level2 = false, start = false;
        Player p;
        Random rnd = new Random();
        PictureBox[] blockArray;
        PictureBox ball;
        Score scoreValue;
        public brickBreaker()
        {
            InitializeComponent();
            startTheGame();
        }

        public void startTheGame()
        {
            createPlayer();
            createBall();
            placeBlocks();
            setupTheGame();
            timer.Start();
        }

        public void createPlayer()
        {
            p = new Player();
            Controls.Add(p.player);
        }

        public void createBall()
        {
            var blockcreator = new BlockCreator(new BallBuilder());
            blockcreator.createBlock(0);
            var b = blockcreator.getBlock();
            ball = b.block;
            Controls.Add(ball);
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

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                p.behaviour = new InitialBehaviour();
                removeBlocks();
                Controls.Remove(p.player);
                Controls.Remove(ball);
                startTheGame();
            }
        }

        private void placeBlocks()
        {
            blockArray = new PictureBox[totalnumberofbricks];
            for (int i = 0; i < blockArray.Length; i++)
            {
                BlockCreator blockcreator;

                if (!level2) blockcreator = new BlockCreator(new LargeBlocksBuilder());
                else blockcreator = new BlockCreator(new SmallBlocksBuilder());

                blockcreator.createBlock(i);
                var b = blockcreator.getBlock();
                blockArray[i] = b.block;
                Controls.Add(blockArray[i]);
            }
        }

        private void setupTheGame()
        {
            scoreValue = Score.getScore();
            createScoreLabel();
            isGameOver = false;
            ScoreLabel.Text = "Score = " + scoreValue.scoreCount;
            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }

        public void createScoreLabel()
        {
            ScoreLabel = scoreValue.scorelabel;
            Controls.Add(ScoreLabel);
        }

        void ballCode()
        {
            ball.Left += ballX;
            ball.Top += ballY;

            if (ball.Left < minballleft || ball.Left > maxballright) ballX = -ballX;
            if (ball.Top < minballtop) ballY = -ballY;

            if (ball.Bounds.IntersectsWith(p.player.Bounds))
            {
                ballY = rnd.Next(5, 12) * -1;
                if (ballX < 0) ballX = rnd.Next(5, 12) * -1;
                else ballX = rnd.Next(5, 12);
            }

            foreach (Control x in Controls)
            {
                if ((x is PictureBox && (string)x.Tag == "Blocks") && ball.Bounds.IntersectsWith(x.Bounds))
                {
                    numberofremovedbricks++;
                    scoreValue.scoreCount += 1;
                    ballY = -ballY;
                    Controls.Remove(x);
                }
            }
        }

        void scoreCode()
        {
            ScoreLabel.Text = "Score = " + scoreValue.scoreCount;

            if (numberofremovedbricks == totalnumberofbricks)
            {
                numberofremovedbricks = 0;
                gameOver("You Won, Press enter to play again");
                level2 = true;
            }
            if (ball.Top > maxballtop)
            {
                gameOver("You Lost, Press enter to play again");
                numberofremovedbricks = 0;
                scoreValue.scoreCount = 0;
                level2 = false;
            }

        }
        private void gameOver(string message)
        {
            isGameOver = true;
            start = false;
            timer.Stop();
            MessageBox.Show(message);
        }

        private void removeBlocks()
        {
            foreach (PictureBox x in blockArray)
            {
                Controls.Remove(x);
            }
        }
    }
}
