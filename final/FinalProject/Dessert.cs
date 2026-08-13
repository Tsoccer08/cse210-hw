// Represents a dessert menu item.
class Dessert : FoodItem
{
	private readonly string _flavor;

	// Creates a new dessert.
	public Dessert(string name, double price, bool isVegetarian, string flavor)
		: base(name, price, isVegetarian, false)
	{
		_flavor = flavor;
	}

	// Returns the dessert's information for the menu and receipt.
	public override string PrintItem()
	{
		return $"{_name} - {_flavor} - ${_price:F2}";
	}
}