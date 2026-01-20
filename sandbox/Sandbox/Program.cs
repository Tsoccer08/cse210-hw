using System;

namespace Sandbox
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Unit Converter Calculator\n");
            Console.Write("Enter Inches to convert to Centimeters- ");
            string answer = Console.ReadLine();
            double inches = double.Parse(answer);
            double centimeters = inches * 2.54;
            Console.WriteLine($"there are {centimeters} centimeters");
        }
    }
}

// comment, don't need one at end.
/* comment */
// to comment out many lines, select them, then do ctrl + /.