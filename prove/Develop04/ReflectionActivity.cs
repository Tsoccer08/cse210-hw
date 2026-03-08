using System;
using System.Collections.Generic;

// Activity that helps users reflect on meaningful past experiences
class ReflectionActivity : Activity
{
    // Prompts that help the user think of an experience to reflect on
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // Questions used to guide deeper reflection
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor sends name and description to the base Activity class
    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times when you have shown strength and resilience.")
    {
    }

    // Runs the Reflection Activity
    public void Run()
    {
        DisplayStartingMessage();

        // Display a reflection prompt
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {_prompts[_rand.Next(_prompts.Count)]} ---");

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions:");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Console.Clear();

        // Display reflection questions until time expires
        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n> {_questions[_rand.Next(_questions.Count)]}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}