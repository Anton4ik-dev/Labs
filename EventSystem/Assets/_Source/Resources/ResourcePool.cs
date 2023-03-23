using System.Collections.Generic;

public class ResourcePool
{
    public Dictionary<int, int> Resources = new Dictionary<int, int>();

    public Resource Wood { get => Resource.Wood; }
    public Resource Iron { get => Resource.Iron; }
    public Resource Gold { get => Resource.Gold; }

    public ResourcePool()
    {
        Resources.Add(0, 0);
        Resources.Add(1, 0);
        Resources.Add(2, 0);
    }
}