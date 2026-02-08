using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<JournalEntry> _entries = new List<JournalEntry>();
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

    private Random _rand = new Random();

    public void AddEntry()
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        Console.Write("Where were you today? ");
        string location = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        _entries.Add(new JournalEntry(date, prompt, response, location));
    }



    public void Display()
    {
        foreach (JournalEntry entry in _entries)
        {
            entry.Display();
        }
    }

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

    public void Load()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        _entries.Clear();

        foreach (string line in File.ReadAllLines(filename))
        {
            _entries.Add(JournalEntry.FromFileString(line));
        }
    }
}