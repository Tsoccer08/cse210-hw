using System;
using System.Collections.Generic;

// Customer inherits from Person
class Customer : Person
{
    // List to keep track of orders
    private List<Order> _orderHistory;
    private Order _currentOrder;

    // Constructor
    public Customer(string name, int id, int age) : base(name, id, age)
    {
        _orderHistory = new List<Order>();
        _currentOrder = new Order();
    }

    // Begin a new order
    public void StartOrder(Waiter waiter)
    {
        _currentOrder = new Order();
        Console.WriteLine($"{waiter.GetName()} is ready to take your order, {GetName()}.");
    }

    // Add an item to current order
    public void AddItemToOrder(FoodItem item)
    {
        if (item != null)
        {
            _currentOrder.AddItem(item);
        }
    }

    // Finalize and save the current order
    public void PlaceOrder()
    {
        _orderHistory.Add(_currentOrder);
        Console.WriteLine("Order has been placed!");
    }

    // Get all previous orders
    public List<Order> GetOrderHistory()
    {
        return _orderHistory;
    }

    // Get the latest order
    public Order GetLatestOrder()
    {
        if (_orderHistory.Count > 0)
            return _orderHistory[_orderHistory.Count - 1];
        else
            return null;
    }
}