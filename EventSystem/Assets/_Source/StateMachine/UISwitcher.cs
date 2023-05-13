using System;
using System.Collections.Generic;

public class UISwitcher
{
    public Dictionary<Type, IUIController> states = new Dictionary<Type, IUIController>();
    private IUIController _activeState;

    public void Initialize(IUIController mainMenuState, IUIController addMenuState, IUIController removeMenuState)
    {
        states.Add(typeof(MainMenuController), mainMenuState);
        states.Add(typeof(AddMenuController), addMenuState);
        states.Add(typeof(RemoveMenuController), removeMenuState);
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