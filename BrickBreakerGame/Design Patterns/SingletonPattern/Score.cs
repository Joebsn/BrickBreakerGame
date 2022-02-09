using System.Windows.Forms;

namespace BrickBreakerGame.Design_Patterns.SingletonPattern
{
    public sealed class Score
    {
        private static volatile Score _score;
        private static object _scoreLock = new object();
        private int scorecount;
        public Label scorelabel;
        public Score()
        {
            scorecount = 0;
            scorelabel = new Label();
            scorelabel.BackColor = System.Drawing.Color.Azure;
            scorelabel.Tag = "ScoreLabel";
            scorelabel.Left = 5;
            scorelabel.Top = 5;
            scorelabel.Size = new System.Drawing.Size(70, 15);
        }

        public static Score getScore()
        {
            if (_score == null)
            {
                lock (_scoreLock)
                {
                    if (_score == null) _score = new Score();
                }
            }
            return _score;
        }

        public int scoreCount
        {
            get { return scorecount; }
            set
            {
                scorecount = value;
            }
        }

    }
}
