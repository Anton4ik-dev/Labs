using System;
using UnityEngine;

namespace MV
{
    public class Score
    {
        private ScoreAndHealthView _scoreAndHealthView;
        private AudioSource _bonusSound;
        private int _scoreChangeAmount;

        public static Action OnScoreChange;
        public static Action OnGameEnd;

        public Score(ScoreAndHealthView scoreAndHealthView, AudioSource bonusSound, int scoreChangeAmount)
        {
            _scoreAndHealthView = scoreAndHealthView;
            _bonusSound = bonusSound;
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
            _bonusSound.Play();
            _scoreAndHealthView.UpdateScoreText(_scoreChangeAmount);
        }
    }
}