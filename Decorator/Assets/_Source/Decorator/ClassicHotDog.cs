namespace Decorator
{
    public class ClassicHotDog : ABaseHotDog
    {
        public ClassicHotDog(string name, int cost, int weight) : base(name, cost, weight)
        {
            
        }

        public override int GetCost() => Cost;
        public override int GetWeight() => Weight;
    }
}