namespace Decorator
{
    public class MeatHotDog : ABaseHotDog
    {
        public MeatHotDog(string name, int cost, int weight) : base(name, cost, weight)
        {

        }

        public override int GetCost() => Cost;
        public override int GetWeight() => Weight;
    }
}