namespace Decorator
{
    public abstract class HotDogDecorator : ABaseHotDog
    {
        public ABaseHotDog HotDog { get; protected set; }

        public HotDogDecorator(string name, int cost, int weight, ABaseHotDog hotdog) : base(name, cost, weight)
        {
            HotDog = hotdog;
        }

        public override int GetCost() => HotDog.GetCost();
        public override int GetWeight() => HotDog.GetWeight();
    }
}