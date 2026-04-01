public abstract class Person
{
    protected string _name;
    protected int _id;

    public Person(string name, int id)
    {
        _name = name;
        _id = id;
    }

    public string GetName() => _name;
    public int GetID() => _id;
    public string DisplayInfo() => $"ID: {_id}, Name: {_name}";
}