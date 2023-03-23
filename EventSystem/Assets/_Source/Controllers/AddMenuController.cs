using System.Collections.Generic;

public class AddMenuController : IUIController, IGameEventListener
{
    private AddMenuView _addMenuView;
    private ResourcePool _resourcePool;

    private EventSO _eventSO;

    public UISwitcher UISwitcher { get; set; }

    public AddMenuController(AddMenuView addMenuView, ResourcePool resourcePool, UISwitcher uiSwitcher, EventSO eventSO)
    {
        _addMenuView = addMenuView;
        _resourcePool = resourcePool;
        UISwitcher = uiSwitcher;

        _addMenuView.AddMenuButton.onClick.AddListener(ChangeState);

        _addMenuView.RemoveButton.onClick.AddListener(Add);

        _eventSO = eventSO;
        _eventSO.RegisterObserver(this);

        _addMenuView.DropDown.AddOptions(new List<string> { _resourcePool.Wood.ToString(), _resourcePool.Iron.ToString(), _resourcePool.Gold.ToString() });
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

    public void Notify()
    {
        _resourcePool.Resources[_addMenuView.DropDown.value] += int.Parse(_addMenuView.InputField.text);

        SetText();
    }

    private void Add()
    {
        _eventSO.Notify();
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
}