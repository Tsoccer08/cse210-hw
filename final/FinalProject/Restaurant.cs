using System;
using System.Collections.Generic;

// Represents a restaurant with a menu and a team of waiters.
class Restaurant
{
	private readonly string _name;
	private readonly List<FoodItem> _menu;
	private readonly List<Waiter> _waiters;

	// Creates a new restaurant with a default team of waiters.
	public Restaurant(string name)
	{
		_name = name;
		_menu = new List<FoodItem>();

		_waiters = new List<Waiter>
		{
			new Waiter("Alice", 1, "Waiter"),
			new Waiter("Bob", 2, "Waiter"),
			new Waiter("Charlie", 3, "Waiter")
		};
	}

	// Returns the restaurant's name.
	public string GetName()
	{
		return _name;
	}

	// Adds a food item to the restaurant's menu.
	public void AddMenuItem(FoodItem item)
	{
		if (item != null)
		{
			_menu.Add(item);
		}
	}

	// Displays every item on the restaurant's menu.
	public void ShowMenu()
	{
		Console.WriteLine($"\nMenu for {_name}:");

		foreach (FoodItem item in _menu)
		{
			Console.WriteLine(item.PrintItem());
		}
	}

	// Randomly assigns a waiter to the customer.
	public Waiter AssignWaiter()
	{
		Random random = new Random();
		return _waiters[random.Next(_waiters.Count)];
	}

	// Displays menu items of a specific type and allows the customer
	// to select an item or choose none.
	public FoodItem ChooseItemWithNone(string type)
	{
		List<FoodItem> filteredItems = _menu.FindAll(
			item => item.GetType().Name == type
		);

		if (filteredItems.Count == 0)
		{
			Console.WriteLine("No items available.");
			return null;
		}

		Console.WriteLine($"\nChoose a {type.ToLower()} from {_name}:");

		for (int i = 0; i < filteredItems.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {filteredItems[i].PrintItem()}");
		}

		Console.WriteLine("0. None");

		int choice;

		while (true)
		{
			Console.Write("Enter choice: ");
			string input = Console.ReadLine();

			if (int.TryParse(input, out choice) &&
				choice >= 0 &&
				choice <= filteredItems.Count)
			{
				break;
			}

			Console.WriteLine("Invalid input. Try again.");
		}

		if (choice == 0)
		{
			return null;
		}

		return filteredItems[choice - 1];
	}
}