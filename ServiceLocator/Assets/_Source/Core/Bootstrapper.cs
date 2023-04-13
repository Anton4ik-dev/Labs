using SaveSystem;
using UISystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MainScreenView mainScreenView;
        [SerializeField] private AdditionalScreenView additionalScreenView;
        [SerializeField] private AudioSource openSound;
        [SerializeField] private AudioSource exitSound;

        private void Start()
        {
            IServiceLocator serviceLocator = new ServiceLocator(openSound, exitSound);

            UISwitcher uiSwitcher = new UISwitcher();

            serviceLocator.GetService(out IFadeService fadeService);
            serviceLocator.GetService(out ISoundPlayer soundPlayer);
            serviceLocator.GetService(out ISaver scoreSaver);
            Score score = new Score(scoreSaver, additionalScreenView);
            IUIState mainScreen = new MainScreen(fadeService, soundPlayer, uiSwitcher, mainScreenView);
            IUIState additionalScreen = new AdditionalScreen(fadeService, soundPlayer, uiSwitcher, additionalScreenView, score);

            uiSwitcher.Construct(mainScreen, additionalScreen);
            uiSwitcher.ChangeState(mainScreen);
        }
    }
}