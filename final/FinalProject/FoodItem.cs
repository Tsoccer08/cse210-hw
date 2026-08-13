using System;

// Base class for all food and drink items.
class FoodItem
{
	protected string _name;
	protected double _price;
	protected bool _isVegetarian;
	protected bool _isGlutenFree;

	// Creates a new food item.
	public FoodItem(string name, double price, bool isVegetarian, bool isGlutenFree)
	{
		_name = name;
		_price = Math.Round(price, 2);
		_isVegetarian = isVegetarian;
		_isGlutenFree = isGlutenFree;
	}

	// Returns the item's name.
	public string GetName()
	{
		return _name;
	}

	// Returns the item's price.
	public double GetPrice()
	{
		return _price;
	}

	// Returns whether the item is vegetarian.
	public bool GetVegetarian()
	{
		return _isVegetarian;
	}

	// Returns whether the item is gluten-free.
	public bool GetGlutenFree()
	{
		return _isGlutenFree;
	}

	// Returns the basic item information.
	// Derived classes can override this to provide more details.
	public virtual string PrintItem()
	{
		return $"{_name} - ${_price:F2}";
	}
}