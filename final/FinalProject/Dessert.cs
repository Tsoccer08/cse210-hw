public class Dessert : FoodItem
{
    private bool _hasTopping;
    private string _flavor;

    public Dessert(string name, double basePrice, bool hasTopping, string flavor)
        : base(name, basePrice)
    {
        _hasTopping = hasTopping;
        _flavor = flavor;
    }

    public override double CalculatePrice() => _basePrice;
    public override string GetDescription() => _name;
    public void AddTopping() { }
    public void RemoveTopping() { }
}