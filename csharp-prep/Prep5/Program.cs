using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();

        int birthYear;
        PromptUserBirthYear(out birthYear);

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(name, squaredNumber, birthYear);


            static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        // Prompts for and returns the user's name
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        // Prompts for and returns the user's favorite number
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            return int.Parse(Console.ReadLine());
        }

        // Prompts for the user's birth year using an out parameter
        static void PromptUserBirthYear(out int birthYear)
        {
            Console.Write("Please enter the year you were born: ");
            birthYear = int.Parse(Console.ReadLine());
        }

        // Returns the square of a number
        static int SquareNumber(int number)
        {
            return number * number;
        }

        // Displays the final results
        static void DisplayResult(string name, int squaredNumber, int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
            Console.WriteLine($"{name}, you will turn {age} this year.");
        }
    }
}
