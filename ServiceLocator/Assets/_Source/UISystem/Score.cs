namespace UISystem
{
    public class Score
    {
        private int _score;
        public int ScoreAmount { get => _score; }

        public void ChangeScore() => ++_score;
    }
}