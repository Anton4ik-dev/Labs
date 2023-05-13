using System.Collections.Generic;
using UnityEngine;

public class RemoveMenuController : IUIController, IGameEventListener
{
    private RemoveMenuView _removeMenuView;
    private ResourcePool _resourcePool;

    private EventSO _eventSO;

    public UISwitcher UISwitcher { get; set; }

    public RemoveMenuController(RemoveMenuView removeMenuView, ResourcePool resourcePool, UISwitcher uiSwitcher, EventSO eventSO)
    {
        _removeMenuView = removeMenuView;
        _resourcePool = resourcePool;
        UISwitcher = uiSwitcher;

        _removeMenuView.RemoveMenuButton.onClick.AddListener(ChangeState);
        _removeMenuView.RemoveButton.onClick.AddListener(Remove);

        _eventSO = eventSO;
        _eventSO.RegisterObserver(this);

        _removeMenuView.DropDown.AddOptions(new List<string> { _resourcePool.Wood.ToString(), _resourcePool.Iron.ToString(), _resourcePool.Gold.ToString()});
    }

    public void Enter()
    {
        _removeMenuView.RemoveMenuPanel.SetActive(true);
        SetText();
    }

    public void Exit()
    {
        _removeMenuView.RemoveMenuPanel.SetActive(false);
    }

    public void Notify()
    {
        _resourcePool.Resources[_removeMenuView.DropDown.value] -= int.Parse(_removeMenuView.InputField.text);

        if (_resourcePool.Resources[_removeMenuView.DropDown.value] < 0)
            _resourcePool.Resources[_removeMenuView.DropDown.value] = 0;

        SetText();
    }

    private void Remove()
    {
        _eventSO.Notify();
    }

    private void SetText()
    {
        _removeMenuView.DropDown.value = 0;
        _removeMenuView.InputField.text = "";
    }

    private void ChangeState()
    {
        UISwitcher.ChangeState(this);
    }
}