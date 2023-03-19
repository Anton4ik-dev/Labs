using System.Collections.Generic;

public class UISwitcher
{
    public Dictionary<int, IUIController> states;
    private IUIController _activeState;

    public UISwitcher(MainMenuView mainMenuView, AddMenuView addMenuView, RemoveMenuView removeMenuView, ResourcePool resourcePool)
    {
        states = new Dictionary<int, IUIController>();

        states.Add(0, new MainMenuController(mainMenuView, resourcePool, this));
        states.Add(1, new AddMenuController(addMenuView, resourcePool, this));
        states.Add(2, new RemoveMenuController(removeMenuView, resourcePool, this));
    }

    private void ExitState()
    {
        _activeState?.Exit();
    }

    private void EnterState(IUIController newState)
    {
        _activeState = newState;
        _activeState.Enter();
    }

    public void ChangeState(IUIController newState)
    {
        ExitState();
        EnterState(newState);
    }
}