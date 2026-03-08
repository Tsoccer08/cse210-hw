using System;

// Main program that allows the user to select mindfulness activities
class Program
{
    static void Main()
    {
        string choice = "";

        // Continue running until the user selects Quit
        while (choice != "5")
        {
            Console.Clear();

            // Display the activity menu
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            // Run the selected activity
            if (choice == "1")
            {
                new BreathingActivity().Run();
            }
            else if (choice == "2")
            {
                new ReflectionActivity().Run();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
            }
            else if (choice == "4")
            {
                new GratitudeActivity().Run();
            }
        }
    }
}