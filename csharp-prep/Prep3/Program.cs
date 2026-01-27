using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            while (guess != number)
            {
                Console.Write("What is your guess? ");
                string num = Console.ReadLine();
                guess = int.Parse(num);
                guessCount++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
        }
    }
}