using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string value = Console.ReadLine();
        int grade = int.Parse(value);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (letter == "D" || letter == "F")
        {
            Console.WriteLine("\nYou did not pass");
        }
        else
        {
            Console.WriteLine("\nYou passed!");
        }
    }
}