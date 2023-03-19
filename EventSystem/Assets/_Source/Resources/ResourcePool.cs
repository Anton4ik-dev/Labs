public class ResourcePool
{
    private int _woodAmount = 0;
    private int _ironAmount = 0;
    private int _goldAmount = 0;

    public int WoodAmount
    {
        get
        {
            return _woodAmount;
        } 
        set 
        {
            _woodAmount = value;
            if (_woodAmount < 0)
                _woodAmount = 0;
        } 
    }
    public int IronAmount
    {
        get
        {
            return _ironAmount;
        }
        set
        {
            _ironAmount = value;
            if (_ironAmount < 0)
                _ironAmount = 0;
        }
    }
    public int GoldAmount
    {
        get
        {
            return _goldAmount;
        }
        set
        {
            _goldAmount = value;
            if (_goldAmount < 0)
                _goldAmount = 0;
        }
    }

    public Resource Wood { get => Resource.Wood; }
    public Resource Iron { get => Resource.Iron; }
    public Resource Gold { get => Resource.Gold; }
}