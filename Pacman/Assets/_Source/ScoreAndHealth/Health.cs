using System;

namespace MV
{
    public class Health
    {
        private ScoreAndHealthView _scoreAndHealthView;
        private int _health;

        public static Action OnHealthChange;

        public Health(ScoreAndHealthView scoreAndHealthView, int health)
        {
            _scoreAndHealthView = scoreAndHealthView;
            _health = health;
            Bind();
        }

        private void Bind()
        {
            OnHealthChange += ChangeHealth;
        }

        private void Expose()
        {
            OnHealthChange -= ChangeHealth;
        }

        public void ChangeHealth()
        {
            _health--;
            _scoreAndHealthView.UpdateHealthView(_health);
        }
    }
}