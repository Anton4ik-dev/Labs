using SaveSystem;

namespace UISystem
{
    public class Score
    {
        private ISaver _saveService;
        private AdditionalScreenView _additionalScreenView;
        private int _score;

        public Score(ISaver fadeService, AdditionalScreenView additionalScreenView)
        {
            _saveService = fadeService;
            _additionalScreenView = additionalScreenView;
        }

        public void ChangeScore() => _additionalScreenView.UpdateScoreText(++_score);

        public void SaveScore()
        {
            _saveService.SaveScore(_score);
        }
    }
}