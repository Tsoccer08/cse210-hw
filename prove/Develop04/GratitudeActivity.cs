using System;
using System.Collections.Generic;

// Activity that helps the user focus on gratitude and positive thinking
class GratitudeActivity : Activity
{
    // Prompts to help the user think of things they are grateful for
    private List<string> _prompts = new List<string>()
    {
        "What are some things that made you smile today?",
        "Who are people you are thankful to have in your life?",
        "What are some opportunities you are grateful for?",
        "What are some simple things you often take for granted?",
        "What experiences this week are you thankful for?"
    };

    // Tracks how many gratitude items the user lists
    private int _count;

    // Constructor passes activity information to the base class
    public GratitudeActivity() : base(
        "Gratitude",
        "This activity will help you develop a positive mindset by listing things you are thankful for.")
    {
    }

    // Runs the Gratitude Activity
    public void Run()
    {
        DisplayStartingMessage();

        // Display instructions and a random gratitude prompt
        Console.WriteLine("\nList as many things as you are thankful for today.\n");
        Console.WriteLine($"--- {_prompts[_rand.Next(_prompts.Count)]} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        // Allow the user to enter gratitude items until time expires
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"\nYou listed {_count} things you are thankful for!");

        DisplayEndingMessage();
    }
}