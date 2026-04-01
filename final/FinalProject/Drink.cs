public class Drink : FoodItem
{
    private string _size;
    private bool _hasIce;

    public Drink(string name, double basePrice, string size, bool hasIce)
        : base(name, basePrice)
    {
        _size = size;
        _hasIce = hasIce;
    }

    public override double CalculatePrice() => _basePrice;
    public override string GetDescription() => _name;
    public void ChangeSize(string size) { _size = size; }
    public void ToggleIce() { _hasIce = !_hasIce; }
}