using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // scripture reference (multiple verses constructor)
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // Scripture text
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";

        // Split the scripture text into individual words
        string[] splitText = text.Split(" ");

        // List to hold Word objects
        List<Word> words = new List<Word>();

        // Convert each string word into a Word object
        foreach (string word in splitText)
        {
            words.Add(new Word(word));
        }

        // Scripture object using the reference and word list
        Scripture scripture = new Scripture(reference, words);

        // Loop until all words are hidden
        while (!scripture.IsCompletelyHidden())
        {
            // Clear the console screen
            Console.Clear();

            // Display the scripture (reference + words)
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Prompt user for input
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            // If user types quit, exit loop
            if (input != null && input.ToLower() == "quit")
            {
                break;
            }

            // Randomly hide 1–3 visible words
            Random random = new Random();
            int count = random.Next(1, 4);
            scripture.HideRandomWords(count);
        }

        // Final display after all words are hidden
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Program ended.");
    }
}