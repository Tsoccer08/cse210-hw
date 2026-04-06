using System;

// Waiter inherits from Person
class Waiter : Person
{
    private string _role;

    // Constructor
    public Waiter(string name, int id, string role) : base(name, id, 20)
    {
        _role = role;
    }

    public string GetRole()
    {
        return _role;
    }

    // Greet the customer
    public void GreetCustomer(Customer customer)
    {
        Console.WriteLine($"Hi {customer.GetName()}, welcome! I'm {GetName()}, your waiter today.");
    }

    // Ask for an order
    public void AskForOrder()
    {
        Console.WriteLine("What would you like to eat today?");
    }

    // Comment after the customer chooses
    public void CommentOnChoice()
    {
        Console.WriteLine("Excellent choice! I hope you enjoy it.");
    }

    // Deliver an order
    public void DeliverOrder(Order order)
    {
        Console.WriteLine("Here's your food, enjoy!");
    }

    // Funny goodbye
    public void SayGoodbye()
    {
        Console.WriteLine("Thanks for coming! Hope to see you again!");
    }

    // Update status
    public void GiveStatusUpdate()
    {
        Console.WriteLine("All items have been delivered to the customer.");
    }
}