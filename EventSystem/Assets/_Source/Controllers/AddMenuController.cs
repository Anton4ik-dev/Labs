using System.Collections.Generic;

public class AddMenuController : IUIController
{
    private AddMenuView _addMenuView;
    private ResourcePool _resourcePool;

    public UISwitcher UISwitcher { get; set; }

    public AddMenuController(AddMenuView addMenuView, ResourcePool resourcePool, UISwitcher uiSwitcher)
    {
        _addMenuView = addMenuView;
        _resourcePool = resourcePool;
        UISwitcher = uiSwitcher;

        _addMenuView.AddMenuButton.onClick.AddListener(ChangeState);

        _addMenuView.RemoveButton.onClick.AddListener(Add);

        _addMenuView.DropDown.AddOptions(new List<string> { _resourcePool.Wood.ToString(), _resourcePool.Iron.ToString(), _resourcePool.Gold.ToString() });
    }

    private void Add()
    {
        if (_addMenuView.DropDown.value == 0)
            _resourcePool.WoodAmount += int.Parse(_addMenuView.InputField.text);
        else if (_addMenuView.DropDown.value == 1)
            _resourcePool.IronAmount += int.Parse(_addMenuView.InputField.text);
        else if (_addMenuView.DropDown.value == 2)
            _resourcePool.GoldAmount += int.Parse(_addMenuView.InputField.text);

        SetText();
    }

    private void SetText()
    {
        _addMenuView.DropDown.value = 0;
        _addMenuView.InputField.text = "";
    }

    private void ChangeState()
    {
        UISwitcher.ChangeState(this);
    }

    public void Enter()
    {
        _addMenuView.AddMenuPanel.SetActive(true);
        SetText();
    }

    public void Exit()
    {
        _addMenuView.AddMenuPanel.SetActive(false);
    }
}