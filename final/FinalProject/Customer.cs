using System;
using System.Collections.Generic;

// Represents a customer in the restaurant system.
class Customer : Person
{
	private readonly List<Order> _orderHistory;
	private Order _currentOrder;

	// Creates a new customer with an empty order history.
	public Customer(string name, int id, int age) : base(name, id, age)
	{
		_orderHistory = new List<Order>();
		_currentOrder = new Order();
	}

	// Starts a new order and lets the customer know their waiter is ready.
	public void StartOrder(Waiter waiter)
	{
		_currentOrder = new Order();

		if (waiter != null)
		{
			Console.WriteLine($"{waiter.GetName()} is ready to take your order, {GetName()}.");
		}
	}

	// Adds a food item to the customer's current order.
	public void AddItemToOrder(FoodItem item)
	{
		if (item != null)
		{
			_currentOrder.AddItem(item);
		}
	}

	// Finalizes the current order and adds it to the customer's order history.
	public void PlaceOrder()
	{
		_orderHistory.Add(_currentOrder);
		Console.WriteLine("Order has been placed!");
	}

	// Returns the customer's previous orders.
	public List<Order> GetOrderHistory()
	{
		return new List<Order>(_orderHistory);
	}

	// Returns the customer's most recently placed order.
	public Order GetLatestOrder()
	{
		if (_orderHistory.Count == 0)
		{
			return null;
		}

		return _orderHistory[_orderHistory.Count - 1];
	}
}