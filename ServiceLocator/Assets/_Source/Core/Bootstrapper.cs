using UISystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Start()
        {
            UISwitcher uiSwitcher = new UISwitcher();
            uiSwitcher.ChangeState(mainScreen);
        }
    }
}