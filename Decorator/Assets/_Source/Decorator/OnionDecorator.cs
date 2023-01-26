namespace Decorator
{
    public class OnionDecorator : HotDogDecorator
    {
        public OnionDecorator(string name, int cost, int weight, ABaseHotDog hotdog) : base(name, cost, weight, hotdog)
        {

        }

        public override int GetCost() => HotDog.GetCost() + Cost;
        public override int GetWeight() => HotDog.GetWeight() + Cost;
    }
}