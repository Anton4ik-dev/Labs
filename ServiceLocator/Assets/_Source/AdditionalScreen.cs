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

        public AdditionalScreen(IFadeService fadeService, ISoundPlayer soundPlayer, UISwitcher uiSwitcher, AdditionalScreenView additionalScreenView)
        {
            _fadeService = fadeService;
            _soundPlayer = soundPlayer;
            _uiSwitcher = uiSwitcher;
            _additionalScreenView = additionalScreenView;
        }

        private void ChangeState()
        {
            _uiSwitcher.ChangeState(_uiSwitcher.states[typeof(MainScreen)]);
        }

        public void Enter()
        {
            _additionalScreenView.Bind(ChangeState);
            Tween tween = _fadeService.FadeIn(_additionalScreenView.ClosePanel, _additionalScreenView.Duration);
            tween.Play().OnStart(() => _additionalScreenView.ClosePanel.gameObject.SetActive(true));
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _additionalScreenView.Expose();
            Tween tween = _fadeService.FadeOut(_additionalScreenView.ClosePanel, _additionalScreenView.Duration);
            tween.Play().OnComplete(() => _additionalScreenView.ClosePanel.gameObject.SetActive(false));
            _soundPlayer.PlayExitSound();
        }
    }
}