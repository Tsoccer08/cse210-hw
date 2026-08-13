// Represents a drink menu item.
class Drink : FoodItem
{
	private readonly string _size;
	private readonly bool _isCold;

	// Creates a new drink.
	public Drink(string name, double price, string size, bool isCold)
		: base(name, price, false, false)
	{
		_size = size;
		_isCold = isCold;
	}

	// Returns the drink's information for the menu and receipt.
	public override string PrintItem()
	{
		return $"{_name} ({_size}) - ${_price:F2}";
	}
}