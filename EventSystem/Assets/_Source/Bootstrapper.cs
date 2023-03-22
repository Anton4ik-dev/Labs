using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AddMenuView addMenuView;
    [SerializeField] private RemoveMenuView removeMenuView;

    [SerializeField] private EventSO resetEventSO;
    [SerializeField] private EventSO addEventSO;
    [SerializeField] private EventSO removeEventSO;

    private UISwitcher _uiSwitcher;
    private StateInitializer _stateInitializer;

    private void Awake()
    {
        _uiSwitcher = new UISwitcher();

        _stateInitializer = new StateInitializer(mainMenuView, addMenuView, removeMenuView, new ResourcePool(), _uiSwitcher, resetEventSO, addEventSO, removeEventSO);

        _uiSwitcher.Initialize(_stateInitializer.mainMenuState, _stateInitializer.addMenuState, _stateInitializer.removeMenuState);
    }
}