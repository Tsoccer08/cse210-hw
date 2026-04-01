using System;

class Program
{
    static void Main(string[] args)
    {
        Restaurant myRestaurant = new Restaurant("Troy's Diner");
        Customer customer = new Customer("Alice", 1, 5);
        Waiter waiter = new Waiter("Bob", 2, "Waiter");

        waiter.GreetCustomer(customer);
        myRestaurant.ShowMenu();

        customer.StartOrder(waiter);

        Dinner meal = new Dinner("Steak", 15.99, true, false);
        customer.AddItemToOrder(meal);

        customer.PlaceOrder();

        waiter.DeliverOrder(customer.GetOrderHistory()[0]);
        waiter.SayGoodbye();
    }
}