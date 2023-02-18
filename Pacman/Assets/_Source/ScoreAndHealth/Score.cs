using System;

namespace MV
{
    public class Score
    {
        private ScoreAndHealthView _scoreAndHealthView;
        private int _scoreChangeAmount;

        public static Action OnScoreChange;
        public static Action OnGameEnd;

        public Score(ScoreAndHealthView scoreAndHealthView, int scoreChangeAmount)
        {
            _scoreAndHealthView = scoreAndHealthView;
            _scoreChangeAmount = scoreChangeAmount;
            Bind();
        }

        private void Bind()
        {
            OnScoreChange += ChangeScore;
            OnGameEnd += Expose;
        }

        public void Expose()
        {
            OnScoreChange -= ChangeScore;
            OnGameEnd -= Expose;
        }

        public void ChangeScore()
        {
            _scoreAndHealthView.UpdateScoreText(_scoreChangeAmount);
        }
    }
}