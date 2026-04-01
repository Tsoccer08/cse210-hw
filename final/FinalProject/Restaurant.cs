public class Restaurant
{
    private string _name;
    private List<FoodItem> _menu = new List<FoodItem>();
    private List<Order> _orders = new List<Order>();
    private List<Waiter> _waiters = new List<Waiter>();

    public Restaurant(string name)
    {
        _name = name;
    }

    public void AddMenuItem(FoodItem item) => _menu.Add(item);
    public void RemoveMenuItem(FoodItem item) => _menu.Remove(item);
    public void ShowMenu() => Console.WriteLine("Menu placeholder");

    public Order CreateOrder(Customer customer) => new Order(customer, AssignWaiter(), 1);

    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Processing order...");
    }

    public Waiter AssignWaiter()
    {
        return new Waiter("John", 1, "Waiter");
    }

    public List<Order> GetOrders() => _orders;
}