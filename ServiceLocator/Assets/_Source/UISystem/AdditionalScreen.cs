using Core;
using DG.Tweening;
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
            _fadeService = locator.GetService<IFadeService>();
            _soundPlayer = locator.GetService<ISoundPlayer>();
            _saveService = locator.GetService<ISaver>();
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
            _additionalScreenView.Bind(ChangeState, ChangeScore);
            Tween tween = _fadeService.FadeIn(_additionalScreenView.ClosePanel, _additionalScreenView.Duration);
            tween.Play().OnStart(() => _additionalScreenView.ClosePanel.gameObject.SetActive(true));
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _additionalScreenView.Expose();
            _saveService.SaveScore(_score.ScoreAmount);
            Tween tween = _fadeService.FadeOut(_additionalScreenView.ClosePanel, _additionalScreenView.Duration);
            tween.Play().OnComplete(() => _additionalScreenView.ClosePanel.gameObject.SetActive(false));
            _soundPlayer.PlayExitSound();
        }
    }
}