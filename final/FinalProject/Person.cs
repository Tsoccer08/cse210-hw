using System;

// Base class for any person in the restaurant system
class Person
{
    // Fields
    private string _name;
    private int _id;
    private int _age;

    // Constructor
    public Person(string name, int id, int age)
    {
        _name = name;
        _id = id;
        _age = age;
    }

    // Getters and Setters
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetId()
    {
        return _id;
    }

    public void SetId(int id)
    {
        _id = id;
    }

    public int GetAge()
    {
        return _age;
    }

    public void SetAge(int age)
    {
        _age = age;
    }
}