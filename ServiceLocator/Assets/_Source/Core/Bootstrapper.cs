using UISystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private IUISwitcher _uISwitcher;

        [Inject]
        public void Construct(IUISwitcher uISwitcher)
        {
            _uISwitcher = uISwitcher;
        }

        private void Start()
        {
            _uISwitcher.ChangeState(_uISwitcher.States[typeof(MainScreen)]);
        }
    }
}