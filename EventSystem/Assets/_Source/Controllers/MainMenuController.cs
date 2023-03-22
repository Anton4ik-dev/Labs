using deVoid.Utils;
using UnityEngine;

public class MainMenuController : IUIController
{
    private MainMenuView _mainMenuView;
    private ResourcePool _resourcePool;

    private CardView _wood;
    private CardView _iron;
    private CardView _gold;

    public UISwitcher UISwitcher { get; set; }

    public MainMenuController(MainMenuView menuView, ResourcePool resourcePool, UISwitcher uiSwitcher)
    {
        _mainMenuView = menuView;
        _resourcePool = resourcePool;
        UISwitcher = uiSwitcher;

        _mainMenuView.MainMenuButton.onClick.AddListener(ChangeState);
        _mainMenuView.ResetButton.onClick.AddListener(Reset);

        _wood = GameObject.Instantiate(_mainMenuView.Card, _mainMenuView.Group);
        _iron = GameObject.Instantiate(_mainMenuView.Card, _mainMenuView.Group);
        _gold = GameObject.Instantiate(_mainMenuView.Card, _mainMenuView.Group);

        _wood.MaterialName.text = _resourcePool.Wood.ToString();
        _iron.MaterialName.text = _resourcePool.Iron.ToString();
        _gold.MaterialName.text = _resourcePool.Gold.ToString();

        Signals.Get<ResetSignal>().AddListener(Notify);

        SetText();
    }

    public void Enter()
    {
        _mainMenuView.MainMenuPanel.SetActive(true);
        SetText();
    }

    public void Exit()
    {
        _mainMenuView.MainMenuPanel.SetActive(false);
    }

    public void Notify()
    {
        _resourcePool.WoodAmount = 0;
        _resourcePool.IronAmount = 0;
        _resourcePool.GoldAmount = 0;

        SetText();
    }

    private void Reset()
    {
        Signals.Get<ResetSignal>().Dispatch();
    }

    private void SetText()
    {
        _wood.MaterialAmount.text = _resourcePool.WoodAmount.ToString();
        _iron.MaterialAmount.text = _resourcePool.IronAmount.ToString();
        _gold.MaterialAmount.text = _resourcePool.GoldAmount.ToString();
    }

    private void ChangeState()
    {
        UISwitcher.ChangeState(this);
    }
}