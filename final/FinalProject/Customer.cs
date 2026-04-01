public class Customer : Person
{
    private List<Order> _orderHistory = new List<Order>();
    private Order _currentOrder;
    private int _tableNumber;

    public Customer(string name, int id, int tableNumber) : base(name, id)
    {
        _tableNumber = tableNumber;
    }

    public void StartOrder(Waiter waiter)
    {
        _currentOrder = new Order(this, waiter, _tableNumber);
    }

    public void AddItemToOrder(FoodItem item) => _currentOrder?.AddItem(item);

    public void PlaceOrder()
    {
        if (_currentOrder != null)
        {
            _orderHistory.Add(_currentOrder);
        }
    }

    public string ViewCurrentOrder() => _currentOrder != null ? "Order started." : "No current order.";
    public List<Order> GetOrderHistory() => _orderHistory;
}