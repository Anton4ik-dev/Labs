namespace Decorator
{
    public class CesarHotDog : ABaseHotDog
    {
        public CesarHotDog(string name, int cost, int weight) : base(name, cost, weight)
        {

        }

        public override int GetCost() => Cost;
        public override int GetWeight() => Weight;
    }
}