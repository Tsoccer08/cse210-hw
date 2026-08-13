using System;
using System.Collections.Generic;

// Main program for the multi-restaurant dining simulator.
class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("========================================");
		Console.WriteLine("   Welcome to the Dining Simulator!");
		Console.WriteLine("========================================");

		Console.Write("Please enter your name: ");
		string customerName = Console.ReadLine();

		if (string.IsNullOrWhiteSpace(customerName))
		{
			customerName = "Guest";
		}

		Customer customer = new Customer(customerName, 1, 25);

		List<Restaurant> restaurants = new List<Restaurant>
		{
			CreateRestaurant1(),
			CreateRestaurant2(),
			CreateRestaurant3(),
			CreateRestaurant4()
		};

		Console.WriteLine("\nAvailable Restaurants:");

		for (int i = 0; i < restaurants.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {restaurants[i].GetName()}");
		}

		int restaurantChoice = GetValidatedChoice(
			1,
			restaurants.Count,
			"Choose a restaurant by number: "
		);

		Restaurant chosenRestaurant = restaurants[restaurantChoice - 1];

		Console.WriteLine($"\nYou selected {chosenRestaurant.GetName()}!");

		Waiter waiter = chosenRestaurant.AssignWaiter();
		waiter.GreetCustomer(customer);
		waiter.AskForOrder();

		FoodItem dinner = chosenRestaurant.ChooseItemWithNone("Dinner");
		FoodItem drink = chosenRestaurant.ChooseItemWithNone("Drink");
		FoodItem dessert = chosenRestaurant.ChooseItemWithNone("Dessert");

		if (dinner == null && drink == null && dessert == null)
		{
			Console.WriteLine(
				"\nWaiter: Wow, someone doesn't want anything! Fine, suit yourself! Goodbye!"
			);
			return;
		}

		customer.StartOrder(waiter);

		if (dinner != null)
		{
			customer.AddItemToOrder(dinner);
		}

		if (drink != null)
		{
			customer.AddItemToOrder(drink);
		}

		if (dessert != null)
		{
			customer.AddItemToOrder(dessert);
		}

		waiter.CommentOnChoice();

		customer.PlaceOrder();

		waiter.GiveStatusUpdate();
		waiter.DeliverOrder(customer.GetLatestOrder());

		Console.WriteLine("\n========================================");
		Console.WriteLine("              YOUR RECEIPT");
		Console.WriteLine("========================================");
		Console.WriteLine(customer.GetLatestOrder().PrintReceipt());
		Console.WriteLine("========================================");

		waiter.SayGoodbye();
	}

	// Gets a valid numeric choice from the user.
	static int GetValidatedChoice(int min, int max, string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string input = Console.ReadLine();

			if (int.TryParse(input, out int choice) &&
				choice >= min &&
				choice <= max)
			{
				return choice;
			}

			Console.WriteLine("Invalid input. Try again.");
		}
	}

	// Creates the first restaurant and its menu.
	static Restaurant CreateRestaurant1()
	{
		Restaurant restaurant = new Restaurant("Tasty Town");

		restaurant.AddMenuItem(new Dinner("Steak", 15.99, false, false));
		restaurant.AddMenuItem(new Dinner("Salmon", 13.49, false, false));
		restaurant.AddMenuItem(new Dinner("Veggie Pasta", 11.99, true, false));
		restaurant.AddMenuItem(new Dinner("Chicken Parmesan", 14.99, false, true));
		restaurant.AddMenuItem(new Dinner("Beef Tacos", 12.49, false, false));
		restaurant.AddMenuItem(new Dinner("Tofu Stir Fry", 10.99, true, false));
		restaurant.AddMenuItem(new Dinner("Lamb Chops", 18.99, false, false));
		restaurant.AddMenuItem(new Dinner("Pork Ribs", 16.49, false, false));
		restaurant.AddMenuItem(new Dinner("Quinoa Salad", 9.99, true, false));
		restaurant.AddMenuItem(new Dinner("Shrimp Alfredo", 14.99, false, true));

		restaurant.AddMenuItem(new Drink("Coke", 1.99, "Medium", true));
		restaurant.AddMenuItem(new Drink("Water", 0.00, "Medium", true));
		restaurant.AddMenuItem(new Drink("Orange Juice", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Beer", 3.99, "Large", true));
		restaurant.AddMenuItem(new Drink("Coffee", 1.49, "Small", false));
		restaurant.AddMenuItem(new Drink("Tea", 1.49, "Small", false));
		restaurant.AddMenuItem(new Drink("Milkshake", 2.99, "Medium", true));
		restaurant.AddMenuItem(new Drink("Lemonade", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Iced Tea", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Smoothie", 3.49, "Medium", true));

		restaurant.AddMenuItem(new Dessert("Cheesecake", 4.99, true, "Cheese"));
		restaurant.AddMenuItem(new Dessert("Chocolate Cake", 4.49, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Fruit Tart", 3.99, true, "Mixed Fruit"));
		restaurant.AddMenuItem(new Dessert("Ice Cream", 2.99, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Brownie", 3.49, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Apple Pie", 3.99, true, "Apple"));
		restaurant.AddMenuItem(new Dessert("Pudding", 2.99, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Cupcake", 2.49, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Macarons", 4.49, true, "Mixed"));
		restaurant.AddMenuItem(new Dessert("Creme Brulee", 5.49, true, "Vanilla"));

		return restaurant;
	}

	// Creates the second restaurant and its menu.
	static Restaurant CreateRestaurant2()
	{
		Restaurant restaurant = new Restaurant("Bistro Bliss");

		restaurant.AddMenuItem(new Dinner("Sushi Platter", 17.99, false, true));
		restaurant.AddMenuItem(new Dinner("Ramen", 12.99, false, true));
		restaurant.AddMenuItem(new Dinner("Tempura Veggies", 10.99, true, false));
		restaurant.AddMenuItem(new Dinner("Teriyaki Chicken", 14.49, false, false));
		restaurant.AddMenuItem(new Dinner("Beef Bulgogi", 15.99, false, false));
		restaurant.AddMenuItem(new Dinner("Vegan Curry", 11.49, true, false));
		restaurant.AddMenuItem(new Dinner("Seafood Udon", 16.99, false, false));
		restaurant.AddMenuItem(new Dinner("Pork Katsu", 14.99, false, false));
		restaurant.AddMenuItem(new Dinner("Tofu Salad", 9.99, true, false));
		restaurant.AddMenuItem(new Dinner("Spicy Tuna Roll", 13.99, false, false));

		restaurant.AddMenuItem(new Drink("Green Tea", 1.99, "Medium", false));
		restaurant.AddMenuItem(new Drink("Sake", 4.49, "Small", false));
		restaurant.AddMenuItem(new Drink("Ramune", 2.99, "Medium", true));
		restaurant.AddMenuItem(new Drink("Water", 0.00, "Medium", true));
		restaurant.AddMenuItem(new Drink("Iced Matcha", 3.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Lemon Water", 1.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Beer", 3.99, "Large", true));
		restaurant.AddMenuItem(new Drink("Plum Juice", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Milk Tea", 2.99, "Medium", true));
		restaurant.AddMenuItem(new Drink("Smoothie", 3.49, "Medium", true));

		restaurant.AddMenuItem(new Dessert("Mochi", 2.99, true, "Red Bean"));
		restaurant.AddMenuItem(new Dessert("Green Tea Ice Cream", 3.49, true, "Green Tea"));
		restaurant.AddMenuItem(new Dessert("Dorayaki", 3.99, true, "Red Bean"));
		restaurant.AddMenuItem(new Dessert("Taiyaki", 4.49, true, "Custard"));
		restaurant.AddMenuItem(new Dessert("Chocolate Mochi", 3.99, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Anmitsu", 4.49, true, "Fruity"));
		restaurant.AddMenuItem(new Dessert("Matcha Pudding", 3.49, true, "Matcha"));
		restaurant.AddMenuItem(new Dessert("Sweet Rice Cake", 2.99, true, "Rice"));
		restaurant.AddMenuItem(new Dessert("Fruit Parfait", 4.99, true, "Mixed Fruit"));
		restaurant.AddMenuItem(new Dessert("Ice Cream Sandwich", 3.49, true, "Vanilla"));

		return restaurant;
	}

	// Creates the third restaurant and its menu.
	static Restaurant CreateRestaurant3()
	{
		Restaurant restaurant = new Restaurant("Comfort Eats");

		restaurant.AddMenuItem(new Dinner("Burger", 10.99, false, false));
		restaurant.AddMenuItem(new Dinner("Cheeseburger", 11.49, false, false));
		restaurant.AddMenuItem(new Dinner("Veggie Burger", 9.99, true, false));
		restaurant.AddMenuItem(new Dinner("Chicken Wings", 12.99, false, false));
		restaurant.AddMenuItem(new Dinner("Mac and Cheese", 10.49, true, false));
		restaurant.AddMenuItem(new Dinner("Grilled Cheese", 8.99, true, false));
		restaurant.AddMenuItem(new Dinner("Hot Dog", 7.99, false, false));
		restaurant.AddMenuItem(new Dinner("Meatloaf", 13.99, false, false));
		restaurant.AddMenuItem(new Dinner("Salmon Dinner", 14.49, false, true));
		restaurant.AddMenuItem(new Dinner("Veggie Stir Fry", 11.49, true, false));

		restaurant.AddMenuItem(new Drink("Soda", 1.99, "Medium", true));
		restaurant.AddMenuItem(new Drink("Water", 0.00, "Medium", true));
		restaurant.AddMenuItem(new Drink("Coffee", 1.49, "Small", false));
		restaurant.AddMenuItem(new Drink("Tea", 1.49, "Small", false));
		restaurant.AddMenuItem(new Drink("Milkshake", 2.99, "Medium", true));
		restaurant.AddMenuItem(new Drink("Juice", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Beer", 3.99, "Large", true));
		restaurant.AddMenuItem(new Drink("Iced Coffee", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Lemonade", 2.49, "Medium", true));
		restaurant.AddMenuItem(new Drink("Smoothie", 3.49, "Medium", true));

		restaurant.AddMenuItem(new Dessert("Brownie", 3.49, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Ice Cream", 2.99, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Apple Pie", 3.99, true, "Apple"));
		restaurant.AddMenuItem(new Dessert("Cupcake", 2.49, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Cheesecake", 4.99, true, "Cheese"));
		restaurant.AddMenuItem(new Dessert("Chocolate Cake", 4.49, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Fruit Tart", 3.99, true, "Mixed Fruit"));
		restaurant.AddMenuItem(new Dessert("Pudding", 2.99, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Macarons", 4.49, true, "Mixed"));
		restaurant.AddMenuItem(new Dessert("Creme Brulee", 5.49, true, "Vanilla"));

		return restaurant;
	}

	// Creates the fourth restaurant and its menu.
	static Restaurant CreateRestaurant4()
	{
		Restaurant restaurant = new Restaurant("Fancy Feast");

		restaurant.AddMenuItem(new Dinner("Filet Mignon", 25.99, false, false));
		restaurant.AddMenuItem(new Dinner("Lobster Tail", 29.99, false, true));
		restaurant.AddMenuItem(new Dinner("Ratatouille", 19.99, true, false));
		restaurant.AddMenuItem(new Dinner("Duck Confit", 27.99, false, false));
		restaurant.AddMenuItem(new Dinner("Pasta Primavera", 21.49, true, false));
		restaurant.AddMenuItem(new Dinner("Rack of Lamb", 28.99, false, false));
		restaurant.AddMenuItem(new Dinner("Seared Scallops", 26.49, false, false));
		restaurant.AddMenuItem(new Dinner("Stuffed Peppers", 18.99, true, false));
		restaurant.AddMenuItem(new Dinner("Chicken Marsala", 23.99, false, false));
		restaurant.AddMenuItem(new Dinner("Vegetable Wellington", 22.49, true, false));

		restaurant.AddMenuItem(new Drink("Champagne", 12.99, "Glass", true));
		restaurant.AddMenuItem(new Drink("Red Wine", 9.99, "Glass", true));
		restaurant.AddMenuItem(new Drink("White Wine", 9.99, "Glass", true));
		restaurant.AddMenuItem(new Drink("Sparkling Water", 3.49, "Bottle", true));
		restaurant.AddMenuItem(new Drink("Cocktail", 10.99, "Glass", true));
		restaurant.AddMenuItem(new Drink("Coffee", 2.49, "Cup", false));
		restaurant.AddMenuItem(new Drink("Tea", 2.49, "Cup", false));
		restaurant.AddMenuItem(new Drink("Lemonade", 3.49, "Glass", true));
		restaurant.AddMenuItem(new Drink("Smoothie", 4.49, "Glass", true));
		restaurant.AddMenuItem(new Drink("Mocktail", 5.49, "Glass", true));

		restaurant.AddMenuItem(new Dessert("Crème Brûlée", 7.49, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Tiramisu", 6.99, true, "Coffee"));
		restaurant.AddMenuItem(new Dessert("Chocolate Lava Cake", 7.49, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Panna Cotta", 6.49, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Macarons", 5.49, true, "Mixed"));
		restaurant.AddMenuItem(new Dessert("Cheesecake", 6.99, true, "Cheese"));
		restaurant.AddMenuItem(new Dessert("Fruit Tart", 6.49, true, "Mixed Fruit"));
		restaurant.AddMenuItem(new Dessert("Ice Cream Sundae", 5.99, true, "Vanilla"));
		restaurant.AddMenuItem(new Dessert("Chocolate Mousse", 6.49, true, "Chocolate"));
		restaurant.AddMenuItem(new Dessert("Crepe Suzette", 7.49, true, "Orange"));

		return restaurant;
	}
}