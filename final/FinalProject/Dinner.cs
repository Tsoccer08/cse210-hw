// Dinner
class Dinner : FoodItem
{
    private bool _isSpicy;
    private bool _containsNuts;

    public Dinner(string name, double price, bool isVegetarian, bool containsNuts)
        : base(name, price, isVegetarian, false)
    {
        _containsNuts = containsNuts;
    }

    public override string PrintItem()
    {
        return $"{_name} - ${_price:F2}" + (_containsNuts ? " (Contains nuts)" : "");
    }
}