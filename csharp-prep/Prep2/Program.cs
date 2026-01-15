using System;
using System.Net.Mail;

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
        else if (grade >= 80 && grade < 90)
        {
            letter = "B";
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        } 

        Console.WriteLine($"Your grade is: {letter}");

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