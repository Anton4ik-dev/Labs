using Zenject;

namespace UISystem
{
    public class MainScreen : AUIState
    {
        private IFadeService _fadeService;
        private ISoundPlayer _soundPlayer;
        private MainScreenView _mainScreenView;

        [Inject]
        public MainScreen(MainScreenView mainScreenView, IFadeService fadeService, ISoundPlayer soundService)
        {
            _fadeService = fadeService;
            _soundPlayer = soundService;
            _mainScreenView = mainScreenView;
        }

        private void ChangeState()
        {
            Owner.ChangeState(Owner.States[typeof(AdditionalScreen)]);
        }

        public override void Enter()
        {
            _mainScreenView.Show(ChangeState, _fadeService.FadeIn(_mainScreenView.OpenPanel, _mainScreenView.Duration));
            _soundPlayer.PlayOpenSound();
        }

        public override void Exit()
        {
            _mainScreenView.Hide(_fadeService.FadeOut(_mainScreenView.OpenPanel, _mainScreenView.Duration));
            _soundPlayer.PlayExitSound();
        }
    }
}