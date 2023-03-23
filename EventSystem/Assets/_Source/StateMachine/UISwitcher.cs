using System.Collections.Generic;

public class UISwitcher
{
    public Dictionary<int, IUIController> states = new Dictionary<int, IUIController>();
    private IUIController _activeState;

    public void Initialize(IUIController mainMenuState, IUIController addMenuState, IUIController removeMenuState)
    {
        states.Add(0, mainMenuState);
        states.Add(1, addMenuState);
        states.Add(2, removeMenuState);
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