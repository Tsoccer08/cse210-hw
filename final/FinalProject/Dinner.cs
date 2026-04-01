public class Dinner : FoodItem
{
    private bool _hasSide;
    private bool _isSpicy;

    public Dinner(string name, double basePrice, bool hasSide, bool isSpicy)
        : base(name, basePrice)
    {
        _hasSide = hasSide;
        _isSpicy = isSpicy;
    }

    public override double CalculatePrice() => _basePrice;
    public override string GetDescription() => _name;
    public void AddSide() { }
    public void RemoveSide() { }
}