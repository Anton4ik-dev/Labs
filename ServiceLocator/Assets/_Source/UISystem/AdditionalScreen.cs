using Core;
using DG.Tweening;

namespace UISystem
{
    public class AdditionalScreen : IUIState
    {
        private IFadeService _fadeService;
        private ISoundPlayer _soundPlayer;
        private UISwitcher _uiSwitcher;
        private AdditionalScreenView _additionalScreenView;
        private Score _score;

        public AdditionalScreen(IFadeService fadeService, ISoundPlayer soundPlayer, UISwitcher uiSwitcher, AdditionalScreenView additionalScreenView, Score score)
        {
            _fadeService = fadeService;
            _soundPlayer = soundPlayer;
            _uiSwitcher = uiSwitcher;
            _additionalScreenView = additionalScreenView;
            _score = score;
        }

        private void ChangeState()
        {
            _uiSwitcher.ChangeState(_uiSwitcher.states[typeof(MainScreen)]);
        }

        public void Enter()
        {
            _additionalScreenView.Bind(ChangeState, _score.ChangeScore);
            Tween tween = _fadeService.FadeIn(_additionalScreenView.ClosePanel, _additionalScreenView.Duration);
            tween.Play().OnStart(() => _additionalScreenView.ClosePanel.gameObject.SetActive(true));
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _additionalScreenView.Expose();
            _score.SaveScore();
            Tween tween = _fadeService.FadeOut(_additionalScreenView.ClosePanel, _additionalScreenView.Duration);
            tween.Play().OnComplete(() => _additionalScreenView.ClosePanel.gameObject.SetActive(false));
            _soundPlayer.PlayExitSound();
        }
    }
}