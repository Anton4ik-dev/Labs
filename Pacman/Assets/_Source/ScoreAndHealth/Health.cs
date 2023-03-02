using System;

namespace MV
{
    public class Health
    {
        private ScoreAndHealthView _scoreAndHealthView;
        private int _health;

        public static Action OnHealthChange;
        public static Action OnGameEnd;

        public Health(ScoreAndHealthView scoreAndHealthView, int health)
        {
            _scoreAndHealthView = scoreAndHealthView;
            _health = health;
            Bind();
        }

        private void Bind()
        {
            OnHealthChange += ChangeHealth;
            OnGameEnd += Expose;
        }

        public void Expose()
        {
            OnHealthChange -= ChangeHealth;
            OnGameEnd -= Expose;
        }

        public void ChangeHealth()
        {
            _scoreAndHealthView.UpdateHealthView(--_health);
        }
    }
}