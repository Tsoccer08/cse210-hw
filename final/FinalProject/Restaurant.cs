using System;
using System.Collections.Generic;

// Restaurant class
class Restaurant
{
    private string _name;
    private List<FoodItem> _menu;
    private List<Waiter> _waiters;

    // Constructor
    public Restaurant(string name)
    {
        _name = name;
        _menu = new List<FoodItem>();
        _waiters = new List<Waiter>()
        {
            new Waiter("Alice", 1, "Waiter"),
            new Waiter("Bob", 2, "Waiter"),
            new Waiter("Charlie", 3, "Waiter")
        };
    }

    public string GetName()
    {
        return _name;
    }

    // Add item to menu
    public void AddMenuItem(FoodItem item)
    {
        _menu.Add(item);
    }

    // Show all menu items
    public void ShowMenu()
    {
        Console.WriteLine($"\nMenu for {_name}:");
        foreach (var item in _menu)
        {
            Console.WriteLine(item.PrintItem());
        }
    }

    // Randomly assign a waiter
    public Waiter AssignWaiter()
    {
        Random rand = new Random();
        return _waiters[rand.Next(_waiters.Count)];
    }

    // Choose a menu item of a specific type (Dinner, Drink, Dessert) with 0 = none
    public FoodItem ChooseItemWithNone(string type)
    {
        // Filter menu by type
        List<FoodItem> filtered = _menu.FindAll(f => f.GetType().Name == type);

        if (filtered.Count == 0)
        {
            Console.WriteLine("No items available.");
            return null;
        }

        // Display items
        for (int i = 0; i < filtered.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {filtered[i].PrintItem()}");
        }
        Console.WriteLine("0. None");

        int choice = -1;
        while (true)
        {
            Console.Write("Enter choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                if (choice >= 0 && choice <= filtered.Count)
                {
                    break;
                }
            }

            Console.WriteLine("Invalid input. Try again.");
        }

        if (choice == 0)
            return null;

        return filtered[choice - 1];
    }
}