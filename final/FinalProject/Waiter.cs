using System;

// Represents a waiter in the restaurant system.
class Waiter : Person
{
	private readonly string _role;

	// Creates a new waiter.
	public Waiter(string name, int id, string role) : base(name, id, 20)
	{
		_role = role;
	}

	// Returns the waiter's role.
	public string GetRole()
	{
		return _role;
	}

	// Greets a customer.
	public void GreetCustomer(Customer customer)
	{
		if (customer != null)
		{
			Console.WriteLine($"Hi {customer.GetName()}, welcome! I'm {GetName()}, your waiter today.");
		}
	}

	// Asks the customer what they would like to order.
	public void AskForOrder()
	{
		Console.WriteLine("What would you like to eat today?");
	}

	// Responds positively to the customer's selection.
	public void CommentOnChoice()
	{
		Console.WriteLine("Excellent choice! I hope you enjoy it.");
	}

	// Delivers the customer's order.
	public void DeliverOrder(Order order)
	{
		if (order != null)
		{
			Console.WriteLine("Here's your food, enjoy!");
		}
	}

	// Says goodbye to the customer.
	public void SayGoodbye()
	{
		Console.WriteLine("Thanks for coming! Hope to see you again!");
	}

	// Provides an update about the order.
	public void GiveStatusUpdate()
	{
		Console.WriteLine("All items have been delivered to the customer.");
	}
}