public class StateInitializer
{
    public IUIController mainMenuState { get; private set; }
    public IUIController addMenuState { get; private set; }
    public IUIController removeMenuState { get; private set; }

    public StateInitializer(MainMenuView menuView, AddMenuView addView, RemoveMenuView removeView, ResourcePool resourcePool, UISwitcher uiSwitcher, EventSO resetEventSO, EventSO addEventSO, EventSO removeEventSO)
    {
        mainMenuState = new MainMenuController(menuView, resourcePool, uiSwitcher, resetEventSO);
        addMenuState = new AddMenuController(addView, resourcePool, uiSwitcher, addEventSO);
        removeMenuState = new RemoveMenuController(removeView, resourcePool, uiSwitcher, removeEventSO);
    }
}