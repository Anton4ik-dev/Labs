using System.Collections.Generic;

public class RemoveMenuController : IUIController
{
    private RemoveMenuView _removeMenuView;
    private ResourcePool _resourcePool;

    public UISwitcher UISwitcher { get; set; }

    public RemoveMenuController(RemoveMenuView removeMenuView, ResourcePool resourcePool, UISwitcher uiSwitcher)
    {
        _removeMenuView = removeMenuView;
        _resourcePool = resourcePool;
        UISwitcher = uiSwitcher;

        _removeMenuView.RemoveMenuButton.onClick.AddListener(ChangeState);
        _removeMenuView.RemoveButton.onClick.AddListener(Remove);

        _removeMenuView.DropDown.AddOptions(new List<string> { _resourcePool.Wood.ToString(), _resourcePool.Iron.ToString(), _resourcePool.Gold.ToString()});
    }

    private void Remove()
    {
        if (_removeMenuView.DropDown.value == 0)
            _resourcePool.WoodAmount -= int.Parse(_removeMenuView.InputField.text);
        else if(_removeMenuView.DropDown.value == 1)
            _resourcePool.IronAmount -= int.Parse(_removeMenuView.InputField.text);
        else if(_removeMenuView.DropDown.value == 2)
            _resourcePool.GoldAmount -= int.Parse(_removeMenuView.InputField.text);

        SetText();
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

    public void Enter()
    {
        _removeMenuView.RemoveMenuPanel.SetActive(true);
        SetText();
    }

    public void Exit()
    {
        _removeMenuView.RemoveMenuPanel.SetActive(false);
    }
}