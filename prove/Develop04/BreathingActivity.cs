using System;

// Activity that guides the user through controlled breathing
class BreathingActivity : Activity
{
    // Constructor passes activity information to the base class
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    // Runs the breathing exercise
    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Continue breathing instructions until time expires
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(4);

            Console.WriteLine("Now breathe out...");
            ShowCountDown(4);
        }

        DisplayEndingMessage();
    }
}