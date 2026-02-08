using System;
using System.Collections.Generic;
using System.IO;

// Manages the collection of journal entries and user actions
public class Journal
{
    // Stores all journal entries
    public List<JournalEntry> _entries = new List<JournalEntry>();

    // Stores the list of prompts
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the most important thing you learned today?",
        "What prayer was answered during the day?"
    };

    // Random generator used for prompt selection
    private Random _rand = new Random();

    // Adds a new journal entry
    public void AddEntry()
    {
        // Select a random prompt
        string prompt = _prompts[_rand.Next(_prompts.Count)];

        // Get user response
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        // Ask for location
        Console.Write("Where were you today? ");
        string location = Console.ReadLine();

        // Get the current date
        string date = DateTime.Now.ToShortDateString();

        // Create and store the journal entry
        _entries.Add(new JournalEntry(date, prompt, response, location));
    }

    // Displays all journal entries
    public void Display()
    {
        foreach (JournalEntry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all journal entries to a file
    public void Save()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    // Loads journal entries from a file
    public void Load()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        // Clear existing entries before loading new ones
        _entries.Clear();

        foreach (string line in File.ReadAllLines(filename))
        {
            _entries.Add(JournalEntry.FromFileString(line));
        }
    }
}