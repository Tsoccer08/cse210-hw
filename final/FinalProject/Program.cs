using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our multi-restaurant dining simulator!");

        // Ask for the customer's name
        Console.Write("Please enter your name: ");
        string customerName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(customerName))
        {
            customerName = "Guest";
        }

        Customer customer = new Customer(customerName, 1, 25);

        // Create restaurants
        List<Restaurant> restaurants = new List<Restaurant>();
        restaurants.Add(CreateRestaurant1());
        restaurants.Add(CreateRestaurant2());
        restaurants.Add(CreateRestaurant3());
        restaurants.Add(CreateRestaurant4());

        // Show restaurants and ask which one to go to
        Console.WriteLine("\nAvailable Restaurants:");
        for (int i = 0; i < restaurants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {restaurants[i].GetName()}");
        }

        int restChoice = GetValidatedChoice(1, restaurants.Count, "Choose a restaurant by number: ");
        Restaurant chosenRestaurant = restaurants[restChoice - 1];

        // Assign a random waiter
        Waiter waiter = chosenRestaurant.AssignWaiter();
        waiter.GreetCustomer(customer);

        // Ask for dinner, drink, dessert
        FoodItem dinner = chosenRestaurant.ChooseItemWithNone("Dinner");
        FoodItem drink = chosenRestaurant.ChooseItemWithNone("Drink");
        FoodItem dessert = chosenRestaurant.ChooseItemWithNone("Dessert");

        // Funny dialogue if all are 0
        if (dinner == null && drink == null && dessert == null)
        {
            Console.WriteLine("\nWaiter: Wow, someone doesn't want anything! Fine, suit yourself! Goodbye!");
            return;
        }

        // Add items to order
        customer.StartOrder(waiter);
        if (dinner != null) customer.AddItemToOrder(dinner);
        if (drink != null) customer.AddItemToOrder(drink);
        if (dessert != null) customer.AddItemToOrder(dessert);
        customer.PlaceOrder();

        // Deliver and show receipt
        waiter.DeliverOrder(customer.GetLatestOrder());
        Console.WriteLine("\nYour receipt:");
        Console.WriteLine(customer.GetLatestOrder().PrintReceipt());

        waiter.SayGoodbye();
    }

    // Helper method for validated numeric input
    static int GetValidatedChoice(int min, int max, string prompt)
    {
        int choice;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= min && choice <= max)
            {
                break;
            }
            Console.WriteLine("Invalid input. Try again.");
        }
        return choice;
    }

    // Create restaurant 1 with unique menu
    static Restaurant CreateRestaurant1()
    {
        Restaurant r = new Restaurant("Tasty Town");
        r.AddMenuItem(new Dinner("Steak", 15.99, false, false));
        r.AddMenuItem(new Dinner("Salmon", 13.49, false, false));
        r.AddMenuItem(new Dinner("Veggie Pasta", 11.99, true, false));
        r.AddMenuItem(new Dinner("Chicken Parmesan", 14.99, false, true));
        r.AddMenuItem(new Dinner("Beef Tacos", 12.49, false, false));
        r.AddMenuItem(new Dinner("Tofu Stir Fry", 10.99, true, false));
        r.AddMenuItem(new Dinner("Lamb Chops", 18.99, false, false));
        r.AddMenuItem(new Dinner("Pork Ribs", 16.49, false, false));
        r.AddMenuItem(new Dinner("Quinoa Salad", 9.99, true, false));
        r.AddMenuItem(new Dinner("Shrimp Alfredo", 14.99, false, true));

        r.AddMenuItem(new Drink("Coke", 1.99, "Medium", true));
        r.AddMenuItem(new Drink("Water", 0.00, "Medium", true));
        r.AddMenuItem(new Drink("Orange Juice", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Beer", 3.99, "Large", true));
        r.AddMenuItem(new Drink("Coffee", 1.49, "Small", false));
        r.AddMenuItem(new Drink("Tea", 1.49, "Small", false));
        r.AddMenuItem(new Drink("Milkshake", 2.99, "Medium", true));
        r.AddMenuItem(new Drink("Lemonade", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Iced Tea", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Smoothie", 3.49, "Medium", true));

        r.AddMenuItem(new Dessert("Cheesecake", 4.99, true, "Cheese"));
        r.AddMenuItem(new Dessert("Chocolate Cake", 4.49, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Fruit Tart", 3.99, true, "Mixed Fruit"));
        r.AddMenuItem(new Dessert("Ice Cream", 2.99, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Brownie", 3.49, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Apple Pie", 3.99, true, "Apple"));
        r.AddMenuItem(new Dessert("Pudding", 2.99, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Cupcake", 2.49, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Macarons", 4.49, true, "Mixed"));
        r.AddMenuItem(new Dessert("Creme Brulee", 5.49, true, "Vanilla"));

        return r;
    }

    // Create restaurant 2
    static Restaurant CreateRestaurant2()
    {
        Restaurant r = new Restaurant("Bistro Bliss");
        r.AddMenuItem(new Dinner("Sushi Platter", 17.99, false, true));
        r.AddMenuItem(new Dinner("Ramen", 12.99, false, true));
        r.AddMenuItem(new Dinner("Tempura Veggies", 10.99, true, false));
        r.AddMenuItem(new Dinner("Teriyaki Chicken", 14.49, false, false));
        r.AddMenuItem(new Dinner("Beef Bulgogi", 15.99, false, false));
        r.AddMenuItem(new Dinner("Vegan Curry", 11.49, true, false));
        r.AddMenuItem(new Dinner("Seafood Udon", 16.99, false, false));
        r.AddMenuItem(new Dinner("Pork Katsu", 14.99, false, false));
        r.AddMenuItem(new Dinner("Tofu Salad", 9.99, true, false));
        r.AddMenuItem(new Dinner("Spicy Tuna Roll", 13.99, false, false));

        r.AddMenuItem(new Drink("Green Tea", 1.99, "Medium", false));
        r.AddMenuItem(new Drink("Sake", 4.49, "Small", false));
        r.AddMenuItem(new Drink("Ramune", 2.99, "Medium", true));
        r.AddMenuItem(new Drink("Water", 0.00, "Medium", true));
        r.AddMenuItem(new Drink("Iced Matcha", 3.49, "Medium", true));
        r.AddMenuItem(new Drink("Lemon Water", 1.49, "Medium", true));
        r.AddMenuItem(new Drink("Beer", 3.99, "Large", true));
        r.AddMenuItem(new Drink("Plum Juice", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Milk Tea", 2.99, "Medium", true));
        r.AddMenuItem(new Drink("Smoothie", 3.49, "Medium", true));

        r.AddMenuItem(new Dessert("Mochi", 2.99, true, "Red Bean"));
        r.AddMenuItem(new Dessert("Green Tea Ice Cream", 3.49, true, "Green Tea"));
        r.AddMenuItem(new Dessert("Dorayaki", 3.99, true, "Red Bean"));
        r.AddMenuItem(new Dessert("Taiyaki", 4.49, true, "Custard"));
        r.AddMenuItem(new Dessert("Chocolate Mochi", 3.99, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Anmitsu", 4.49, true, "Fruity"));
        r.AddMenuItem(new Dessert("Matcha Pudding", 3.49, true, "Matcha"));
        r.AddMenuItem(new Dessert("Sweet Rice Cake", 2.99, true, "Rice"));
        r.AddMenuItem(new Dessert("Fruit Parfait", 4.99, true, "Mixed Fruit"));
        r.AddMenuItem(new Dessert("Ice Cream Sandwich", 3.49, true, "Vanilla"));

        return r;
    }

    // Create restaurant 3
    static Restaurant CreateRestaurant3()
    {
        Restaurant r = new Restaurant("Comfort Eats");
        r.AddMenuItem(new Dinner("Burger", 10.99, false, false));
        r.AddMenuItem(new Dinner("Cheeseburger", 11.49, false, false));
        r.AddMenuItem(new Dinner("Veggie Burger", 9.99, true, false));
        r.AddMenuItem(new Dinner("Chicken Wings", 12.99, false, false));
        r.AddMenuItem(new Dinner("Mac and Cheese", 10.49, true, false));
        r.AddMenuItem(new Dinner("Grilled Cheese", 8.99, true, false));
        r.AddMenuItem(new Dinner("Hot Dog", 7.99, false, false));
        r.AddMenuItem(new Dinner("Meatloaf", 13.99, false, false));
        r.AddMenuItem(new Dinner("Salmon Dinner", 14.49, false, true));
        r.AddMenuItem(new Dinner("Veggie Stir Fry", 11.49, true, false));

        r.AddMenuItem(new Drink("Soda", 1.99, "Medium", true));
        r.AddMenuItem(new Drink("Water", 0.00, "Medium", true));
        r.AddMenuItem(new Drink("Coffee", 1.49, "Small", false));
        r.AddMenuItem(new Drink("Tea", 1.49, "Small", false));
        r.AddMenuItem(new Drink("Milkshake", 2.99, "Medium", true));
        r.AddMenuItem(new Drink("Juice", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Beer", 3.99, "Large", true));
        r.AddMenuItem(new Drink("Iced Coffee", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Lemonade", 2.49, "Medium", true));
        r.AddMenuItem(new Drink("Smoothie", 3.49, "Medium", true));

        r.AddMenuItem(new Dessert("Brownie", 3.49, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Ice Cream", 2.99, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Apple Pie", 3.99, true, "Apple"));
        r.AddMenuItem(new Dessert("Cupcake", 2.49, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Cheesecake", 4.99, true, "Cheese"));
        r.AddMenuItem(new Dessert("Chocolate Cake", 4.49, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Fruit Tart", 3.99, true, "Mixed Fruit"));
        r.AddMenuItem(new Dessert("Pudding", 2.99, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Macarons", 4.49, true, "Mixed"));
        r.AddMenuItem(new Dessert("Creme Brulee", 5.49, true, "Vanilla"));

        return r;
    }

    // Create restaurant 4
    static Restaurant CreateRestaurant4()
    {
        Restaurant r = new Restaurant("Fancy Feast");
        r.AddMenuItem(new Dinner("Filet Mignon", 25.99, false, false));
        r.AddMenuItem(new Dinner("Lobster Tail", 29.99, false, true));
        r.AddMenuItem(new Dinner("Ratatouille", 19.99, true, false));
        r.AddMenuItem(new Dinner("Duck Confit", 27.99, false, false));
        r.AddMenuItem(new Dinner("Pasta Primavera", 21.49, true, false));
        r.AddMenuItem(new Dinner("Rack of Lamb", 28.99, false, false));
        r.AddMenuItem(new Dinner("Seared Scallops", 26.49, false, false));
        r.AddMenuItem(new Dinner("Stuffed Peppers", 18.99, true, false));
        r.AddMenuItem(new Dinner("Chicken Marsala", 23.99, false, false));
        r.AddMenuItem(new Dinner("Vegetable Wellington", 22.49, true, false));

        r.AddMenuItem(new Drink("Champagne", 12.99, "Glass", true));
        r.AddMenuItem(new Drink("Red Wine", 9.99, "Glass", true));
        r.AddMenuItem(new Drink("White Wine", 9.99, "Glass", true));
        r.AddMenuItem(new Drink("Sparkling Water", 3.49, "Bottle", true));
        r.AddMenuItem(new Drink("Cocktail", 10.99, "Glass", true));
        r.AddMenuItem(new Drink("Coffee", 2.49, "Cup", false));
        r.AddMenuItem(new Drink("Tea", 2.49, "Cup", false));
        r.AddMenuItem(new Drink("Lemonade", 3.49, "Glass", true));
        r.AddMenuItem(new Drink("Smoothie", 4.49, "Glass", true));
        r.AddMenuItem(new Drink("Mocktail", 5.49, "Glass", true));

        r.AddMenuItem(new Dessert("Crème Brûlée", 7.49, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Tiramisu", 6.99, true, "Coffee"));
        r.AddMenuItem(new Dessert("Chocolate Lava Cake", 7.49, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Panna Cotta", 6.49, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Macarons", 5.49, true, "Mixed"));
        r.AddMenuItem(new Dessert("Cheesecake", 6.99, true, "Cheese"));
        r.AddMenuItem(new Dessert("Fruit Tart", 6.49, true, "Mixed Fruit"));
        r.AddMenuItem(new Dessert("Ice Cream Sundae", 5.99, true, "Vanilla"));
        r.AddMenuItem(new Dessert("Chocolate Mousse", 6.49, true, "Chocolate"));
        r.AddMenuItem(new Dessert("Crepe Suzette", 7.49, true, "Orange"));

        return r;
    }
}