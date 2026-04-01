public class Waiter : Person
{
    private string _role;
    private List<string> _dialogueOptions = new List<string>();
    private int _assignedTable;

    public Waiter(string name, int id, string role) : base(name, id)
    {
        _role = role;
    }

    public void GreetCustomer(Customer customer)
    {
        Console.WriteLine($"Hello {customer.GetName()}, welcome!");
    }

    public void AskForOrder()
    {
        Console.WriteLine("What would you like to order?");
    }

    public void CommentOnOrder()
    {
        Console.WriteLine("Great choice!");
    }

    public void UpdateOrderStatus(Order order)
    {
        Console.WriteLine("Your order is being prepared.");
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine("Here is your order!");
    }

    public void SayGoodbye()
    {
        Console.WriteLine("Thank you for visiting!");
    }

    public string GetRandomDialogue() => "Random dialogue placeholder.";
}