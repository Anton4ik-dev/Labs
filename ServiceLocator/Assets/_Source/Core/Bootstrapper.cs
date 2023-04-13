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
            IUIState mainScreen = new MainScreen(serviceLocator, uiSwitcher, mainScreenView);
            IUIState additionalScreen = new AdditionalScreen(serviceLocator, uiSwitcher, additionalScreenView, new Score());

            uiSwitcher.Construct(mainScreen, additionalScreen);
            uiSwitcher.ChangeState(mainScreen);
        }
    }
}