namespace TennisKata
{
    public class TennisGame1 : ITennisGame
    {
        private int _scorePlayerOne = 0;
        private int _scorePlayerTwo = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void AddPointToPlayer(string playerName)
        {
            if (playerName == "player1")
                _scorePlayerOne += 1;
            else
                _scorePlayerTwo += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (_scorePlayerOne == _scorePlayerTwo)
            {
                score = GetScoreWhenPlayersTied();
            }
            else if (_scorePlayerOne >= 4 || _scorePlayerTwo >= 4)
            {
                score = GetScoreWhenPlayerCanWin();
            }
            else
            {
                score = GetScoreWhenMatchOngoing(score);
            }
            return score;
        }

        private string GetScoreWhenMatchOngoing(string score)
        {
            int tempScore;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = _scorePlayerOne;
                else
                {
                    score += "-";
                    tempScore = _scorePlayerTwo;
                }

                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        private string GetScoreWhenPlayerCanWin()
        {
            string score;
            var minusResult = _scorePlayerOne - _scorePlayerTwo;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string GetScoreWhenPlayersTied()
        {
            string score;
            switch (_scorePlayerOne)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}
