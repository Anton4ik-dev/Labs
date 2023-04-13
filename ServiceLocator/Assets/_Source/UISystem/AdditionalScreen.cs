using Core;
using SaveSystem;

namespace UISystem
{
    public class AdditionalScreen : IUIState
    {
        private IFadeService _fadeService;
        private ISoundPlayer _soundPlayer;
        private ISaver _saveService;
        private UISwitcher _uiSwitcher;
        private AdditionalScreenView _additionalScreenView;
        private Score _score;

        public AdditionalScreen(IServiceLocator locator, UISwitcher uiSwitcher, AdditionalScreenView additionalScreenView, Score score)
        {
            locator.GetService(out IFadeService fadeService);
            locator.GetService(out ISoundPlayer soundService);
            locator.GetService(out ISaver saveService);
            _fadeService = fadeService;
            _soundPlayer = soundService;
            _saveService = saveService;
            _uiSwitcher = uiSwitcher;
            _additionalScreenView = additionalScreenView;
            _score = score;
        }

        private void ChangeState()
        {
            _uiSwitcher.ChangeState(_uiSwitcher.states[typeof(MainScreen)]);
        }

        private void ChangeScore()
        {
            _score.ChangeScore();
            _additionalScreenView.UpdateScoreText(_score.ScoreAmount);
        }

        public void Enter()
        {
            _additionalScreenView.Show(ChangeState, ChangeScore, _fadeService.FadeIn(_additionalScreenView.ClosePanel, _additionalScreenView.Duration));
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _additionalScreenView.Hide(_fadeService.FadeOut(_additionalScreenView.ClosePanel, _additionalScreenView.Duration));
            _saveService.SaveScore(_score.ScoreAmount);
            _soundPlayer.PlayExitSound();
        }
    }
}