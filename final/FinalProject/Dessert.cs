// Dessert
class Dessert : FoodItem
{
    private string _flavor;

    public Dessert(string name, double price, bool isVegetarian, string flavor)
        : base(name, price, isVegetarian, false)
    {
        _flavor = flavor;
    }

    public override string PrintItem()
    {
        return $"{_name} - { _flavor} - ${_price:F2}";
    }
}