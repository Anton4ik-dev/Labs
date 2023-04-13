using Core;
using DG.Tweening;

namespace UISystem
{
    public class MainScreen : IUIState
    {
        private IFadeService _fadeService;
        private ISoundPlayer _soundPlayer;
        private UISwitcher _uiSwitcher;
        private MainScreenView _mainScreenView;

        public MainScreen(IServiceLocator locator, UISwitcher uiSwitcher, MainScreenView mainScreenView)
        {
            _fadeService = locator.GetService<IFadeService>();
            _soundPlayer = locator.GetService<ISoundPlayer>();
            _uiSwitcher = uiSwitcher;
            _mainScreenView = mainScreenView;
        }

        private void ChangeState()
        {
            _uiSwitcher.ChangeState(_uiSwitcher.states[typeof(AdditionalScreen)]);
        }

        public void Enter()
        {
            _mainScreenView.Bind(ChangeState);
            Tween tween = _fadeService.FadeIn(_mainScreenView.OpenPanel, _mainScreenView.Duration);
            tween.Play().OnStart(() => _mainScreenView.OpenPanel.gameObject.SetActive(true));
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _mainScreenView.Expose();
            Tween tween = _fadeService.FadeOut(_mainScreenView.OpenPanel, _mainScreenView.Duration);
            tween.Play().OnComplete(() => _mainScreenView.OpenPanel.gameObject.SetActive(false));
            _soundPlayer.PlayExitSound();
        }
    }
}