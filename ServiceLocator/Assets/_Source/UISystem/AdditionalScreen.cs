using SaveSystem;
using Zenject;

namespace UISystem
{
    public class AdditionalScreen : AUIState
    {
        private IFadeService _fadeService;
        private ISoundPlayer _soundPlayer;
        private ISaver _saveService;
        private AdditionalScreenView _additionalScreenView;
        private Score _score;

        [Inject]
        public AdditionalScreen(AdditionalScreenView additionalScreenView, Score score, IFadeService fadeService, ISoundPlayer soundService, ISaver saveService)
        {
            _fadeService = fadeService;
            _soundPlayer = soundService;
            _saveService = saveService;
            _additionalScreenView = additionalScreenView;
            _score = score;
        }

        private void ChangeState()
        {
            Owner.ChangeState(Owner.States[typeof(MainScreen)]);
        }

        private void ChangeScore()
        {
            _score.ChangeScore();
            _additionalScreenView.UpdateScoreText(_score.ScoreAmount);
        }

        public override void Enter()
        {
            _additionalScreenView.Show(ChangeState, ChangeScore, _fadeService.FadeIn(_additionalScreenView.ClosePanel, _additionalScreenView.Duration));
            _soundPlayer.PlayOpenSound();
        }

        public override void Exit()
        {
            _additionalScreenView.Hide(_fadeService.FadeOut(_additionalScreenView.ClosePanel, _additionalScreenView.Duration));
            _saveService.SaveScore(_score.ScoreAmount);
            _soundPlayer.PlayExitSound();
        }
    }
}