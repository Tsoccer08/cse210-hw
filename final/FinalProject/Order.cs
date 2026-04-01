public class Order
{
    private List<FoodItem> _items = new List<FoodItem>();
    private Customer _customer;
    private Waiter _waiter;
    private DateTime _orderTime;
    private string _status;
    private int _tableNumber;

    public Order(Customer customer, Waiter waiter, int tableNumber)
    {
        _customer = customer;
        _waiter = waiter;
        _tableNumber = tableNumber;
        _orderTime = DateTime.Now;
        _status = "Pending";
    }

    public void AddItem(FoodItem item) => _items.Add(item);
    public void RemoveItem(FoodItem item) => _items.Remove(item);
    public double CalculateTotal() => 0; // placeholder
    public string PrintReceipt() => "Receipt placeholder";
    public void SetStatus(string status) => _status = status;
    public List<FoodItem> GetItems() => _items;
}