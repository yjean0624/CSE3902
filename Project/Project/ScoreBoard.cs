using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ScoreBoard
    {
        private int score;
        public ScoreBoard()
        {
            score = 0;
        }
        public void AddPoints(int points)
        {
            score += points;
        }
        public int GetScore()
        {
            return score;
        }
    }
}
