using System;
using System.Collections.Generic;

// Activity that prompts the user to list positive things in their life
class ListingActivity : Activity
{
    // Prompts used to help the user think of ideas to list
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Tracks how many responses the user enters
    private int _count;

    // Constructor passes activity name and description to the base class
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.")
    {
    }

    // Runs the Listing Activity
    public void Run()
    {
        DisplayStartingMessage();

        // Display instructions and a random prompt
        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {_prompts[_rand.Next(_prompts.Count)]} ---");

        // Countdown before the listing begins
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        // Collect responses until time expires
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

        // Display how many responses the user listed
        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }

    // Returns a random prompt from the list
    public string GetRandomPrompt()
    {
        return _prompts[_rand.Next(_prompts.Count)];
    }
}