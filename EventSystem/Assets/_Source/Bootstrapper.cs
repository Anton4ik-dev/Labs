using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AddMenuView addMenuView;
    [SerializeField] private RemoveMenuView removeMenuView;

    private UISwitcher _uiSwitcher;
    private StateInitializer _stateInitializer;

    private void Awake()
    {
        _uiSwitcher = new UISwitcher();

        _stateInitializer = new StateInitializer(mainMenuView, addMenuView, removeMenuView, new ResourcePool(), _uiSwitcher);

        _uiSwitcher.Initialize(_stateInitializer.mainMenuState, _stateInitializer.addMenuState, _stateInitializer.removeMenuState);
    }
}