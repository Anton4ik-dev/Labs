public interface IUIController
{
    UISwitcher UISwitcher { get; set; }
    void Enter();
    void Exit();
}