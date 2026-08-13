// Base class for people in the restaurant system.
class Person
{
	private string _name;
	private int _id;
	private int _age;

	// Creates a new person.
	public Person(string name, int id, int age)
	{
		_name = name;
		_id = id;
		_age = age;
	}

	// Gets or sets the person's name.
	public string GetName()
	{
		return _name;
	}

	public void SetName(string name)
	{
		_name = name;
	}

	// Gets or sets the person's ID.
	public int GetId()
	{
		return _id;
	}

	public void SetId(int id)
	{
		_id = id;
	}

	// Gets or sets the person's age.
	public int GetAge()
	{
		return _age;
	}

	public void SetAge(int age)
	{
		_age = age;
	}
}