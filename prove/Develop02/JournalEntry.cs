using System;

// Represents a single journal entry
public class JournalEntry
{
    // Stores the date of the entry
    public string _date;

    // Stores the prompt shown to the user
    public string _prompt;

    // Stores the user's response
    public string _response;

    // Stores the location where the entry was written
    public string _location;

    // Creates a new journal entry
    public JournalEntry(string date, string prompt, string response, string location)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _location = location;
    }

    // Converts the entry into a format for saving to a file
    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}|{_location}";
    }

    // Creates a JournalEntry object from a line in a file
    public JournalEntry FromFileString(string line)
    {
        string[] parts = line.Split("|");
        return new JournalEntry(parts[0], parts[1], parts[2], parts[3]);
    }

    // Displays the journal entry to the console
    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt} (Location: {_location})");
        Console.WriteLine(_response);
        Console.WriteLine();
    }
}