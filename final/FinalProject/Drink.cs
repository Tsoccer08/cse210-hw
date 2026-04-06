// Drink
class Drink : FoodItem
{
    private string _size;
    private bool _isCold;

    public Drink(string name, double price, string size, bool isCold)
        : base(name, price, false, false)
    {
        _size = size;
        _isCold = isCold;
    }

    public override string PrintItem()
    {
        return $"{_name} ({_size}) - ${_price:F2}";
    }
}
