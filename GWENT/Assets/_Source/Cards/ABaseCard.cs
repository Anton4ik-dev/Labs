using UnityEngine.UI;

public abstract class ABaseCard
{
    public abstract string Name { get; set; }
    public abstract string Description { get; set; }
    public abstract Image Icon { get; set; }
    public abstract void DoAction();
}