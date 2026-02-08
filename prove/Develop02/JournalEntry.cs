using System;

public class JournalEntry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _location;

    public JournalEntry(string date, string prompt, string response, string location)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _location = location;
    }


    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}|{_location}";
    }


    public static JournalEntry FromFileString(string line)
    {
        string[] parts = line.Split("|");
        return new JournalEntry(parts[0], parts[1], parts[2], parts[3]);
    }


    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt} (Location: {_location})");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

}