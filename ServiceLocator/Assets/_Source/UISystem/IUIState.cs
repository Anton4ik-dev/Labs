namespace UISystem
{
    public abstract class AUIState
    {
        protected IUISwitcher Owner;

        public void SetOwner(IUISwitcher owner)
        {
            Owner = owner;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}