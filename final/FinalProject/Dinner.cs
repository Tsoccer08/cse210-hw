// Represents a dinner menu item.
class Dinner : FoodItem
{
	private readonly bool _containsNuts;

	// Creates a new dinner item.
	public Dinner(string name, double price, bool isVegetarian, bool containsNuts)
		: base(name, price, isVegetarian, false)
	{
		_containsNuts = containsNuts;
	}

	// Returns the dinner's information for the menu and receipt.
	public override string PrintItem()
	{
		string nutWarning = _containsNuts ? " (Contains nuts)" : "";
		return $"{_name} - ${_price:F2}{nutWarning}";
	}
}