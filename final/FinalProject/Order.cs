using System.Collections.Generic;

// Represents a customer's order.
class Order
{
	private readonly List<FoodItem> _items;

	// Creates an empty order.
	public Order()
	{
		_items = new List<FoodItem>();
	}

	// Adds a food item to the order.
	public void AddItem(FoodItem item)
	{
		if (item != null)
		{
			_items.Add(item);
		}
	}

	// Creates a receipt containing all ordered items and the total.
	public string PrintReceipt()
	{
		double total = 0;
		string receipt = "";

		foreach (FoodItem item in _items)
		{
			receipt += item.PrintItem() + "\n";
			total += item.GetPrice();
		}

		receipt += $"Total: ${total:F2}";
		return receipt;
	}
}