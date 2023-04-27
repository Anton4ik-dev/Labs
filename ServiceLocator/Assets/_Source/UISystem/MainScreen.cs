using Zenject;

namespace UISystem
{
    public class MainScreen : IUIState
    {
        private IFadeService _fadeService;
        private ISoundPlayer _soundPlayer;
        private UISwitcher _uiSwitcher;
        private MainScreenView _mainScreenView;

        [Inject]
        public MainScreen(UISwitcher uiSwitcher, MainScreenView mainScreenView, IFadeService fadeService, ISoundPlayer soundService)
        {
            _fadeService = fadeService;
            _soundPlayer = soundService;
            _uiSwitcher = uiSwitcher;
            _mainScreenView = mainScreenView;
        }

        private void ChangeState()
        {
            _uiSwitcher.ChangeState(_uiSwitcher.states[typeof(AdditionalScreen)]);
        }

        public void Enter()
        {
            _mainScreenView.Show(ChangeState, _fadeService.FadeIn(_mainScreenView.OpenPanel, _mainScreenView.Duration));
            _soundPlayer.PlayOpenSound();
        }

        public void Exit()
        {
            _mainScreenView.Hide(_fadeService.FadeOut(_mainScreenView.OpenPanel, _mainScreenView.Duration));
            _soundPlayer.PlayExitSound();
        }
    }
}