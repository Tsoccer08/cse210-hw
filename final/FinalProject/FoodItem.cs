using System;

// Base class for any food item
class FoodItem
{
    protected string _name;
    protected double _price;
    protected bool _isVegetarian;
    protected bool _isGlutenFree;

    public FoodItem(string name, double price, bool isVegetarian, bool isGlutenFree)
    {
        _name = name;
        _price = Math.Round(price, 2); // Ensure 2 decimals
        _isVegetarian = isVegetarian;
        _isGlutenFree = isGlutenFree;
    }

    public string GetName() { return _name; }
    public double GetPrice() { return _price; }
    public bool GetVegetarian() { return _isVegetarian; }
    public bool GetGlutenFree() { return _isGlutenFree; }

    public virtual string PrintItem()
    {
        return $"{_name} - ${_price:F2}";
    }
}