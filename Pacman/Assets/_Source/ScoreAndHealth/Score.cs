using System;

namespace MV
{
    public class Score
    {
        private ScoreAndHealthView _scoreAndHealthView;
        private int _score;
        private int _scoreChangeAmount;

        public static Action OnScoreChange;

        public Score(ScoreAndHealthView scoreAndHealthView, int scoreChangeAmount)
        {
            _scoreAndHealthView = scoreAndHealthView;
            _scoreChangeAmount = scoreChangeAmount;
            Bind();
        }

        private void Bind()
        {
            OnScoreChange += ChangeScore;
        }

        private void Expose()
        {
            OnScoreChange -= ChangeScore;
        }

        public void ChangeScore()
        {
            _score += _scoreChangeAmount;
            _scoreAndHealthView.UpdateScoreText(_score);
        }
    }
}