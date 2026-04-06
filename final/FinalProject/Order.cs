using System;
using System.Collections.Generic;

// Order class to store items
class Order
{
    private List<FoodItem> _items;

    public Order()
    {
        _items = new List<FoodItem>();
    }

    // Add an item
    public void AddItem(FoodItem item)
    {
        if (item != null)
            _items.Add(item);
    }

    // Print the full receipt
    public string PrintReceipt()
    {
        double total = 0;
        string receipt = "";
        foreach (FoodItem item in _items)
        {
            receipt += item.PrintItem() + "\n";
            total += item.GetPrice();
        }
        receipt += $"Total: ${total:F2}";
        return receipt;
    }
}