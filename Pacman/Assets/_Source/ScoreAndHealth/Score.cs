using System;
using UnityEngine;

namespace MV
{
    public class Score
    {
        private ScoreAndHealthView _scoreAndHealthView;
        private AudioSource _bonusSound;

        private int _scoreChangeAmount;
        private int _scoreChangeAmountForEnemy;
        private int _totalScore;
        private int _collectedBonuses;

        public static Action OnScoreChange;
        public static Action<int> OnScoreChangeForEnemies;
        public static Action OnGameEnd;

        public Score(ScoreAndHealthView scoreAndHealthView, AudioSource bonusSound, int scoreChangeAmount, int scoreChangeAmountForEnemy)
        {
            _scoreAndHealthView = scoreAndHealthView;
            _bonusSound = bonusSound;
            _scoreChangeAmount = scoreChangeAmount;
            _scoreChangeAmountForEnemy = scoreChangeAmountForEnemy;
            Bind();
        }

        private void Bind()
        {
            OnScoreChange += ChangeScore;
            OnScoreChangeForEnemies += ChangeScoreForEnemies;
            OnGameEnd += Expose;
        }

        public void Expose()
        {
            OnScoreChange -= ChangeScore;
            OnScoreChangeForEnemies -= ChangeScoreForEnemies;
            OnGameEnd -= Expose;
        }

        public void ChangeScore()
        {
            _bonusSound.Play();
            _totalScore += _scoreChangeAmount;
            _collectedBonuses++;
            _scoreAndHealthView.UpdateScoreText(_totalScore, _collectedBonuses);
        }

        public void ChangeScoreForEnemies(int enemies)
        {
            _totalScore += _scoreChangeAmountForEnemy * enemies;
            _scoreAndHealthView.UpdateScoreText(_totalScore, _collectedBonuses);
        }
    }
}