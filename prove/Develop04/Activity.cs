using System;
using System.Threading;

// Base class containing shared properties and methods for all activities
class Activity
{
    private string _name;
    private string _description;

    // Duration of the activity in seconds
    protected int _duration;

    // Shared random generator used by all activities
    protected static Random _rand = new Random();

    // Constructor sets the activity name and description
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Displays the introduction message and asks for session duration
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like for your session? ");

        // Ensure the user enters a valid positive number
        int seconds;
        while (!int.TryParse(Console.ReadLine(), out seconds) || seconds <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        _duration = seconds;

        Console.Clear();
        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    // Displays the ending message when an activity finishes
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);

        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    // Displays a spinner animation for the specified number of seconds
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i = (i + 1) % spinner.Length;
        }
    }

    // Displays a countdown timer
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Allows duration to be set manually if needed
    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }
}