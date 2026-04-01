public abstract class FoodItem
{
    protected string _name;
    protected double _basePrice;
    protected List<string> _ingredients = new List<string>();
    protected int _prepTime;

    public FoodItem(string name, double basePrice)
    {
        _name = name;
        _basePrice = basePrice;
    }

    public abstract double CalculatePrice();
    public abstract string GetDescription();

    public void AddIngredient(string ingredient) => _ingredients.Add(ingredient);
    public void RemoveIngredient(string ingredient) => _ingredients.Remove(ingredient);
}