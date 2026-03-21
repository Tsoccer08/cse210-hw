using System;

// Entry point of the application
class Program
{
    static void Main(string[] args)
    {
        // Create manager object
        GoalManager manager = new GoalManager();

        // Controls program loop
        bool running = true;

        // Main loop runs until user quits
        while (running)
        {
            // Display current score and level
            Console.WriteLine($"\nYou have {manager.GetScore()} points.");
            Console.WriteLine($"Level: {manager.GetLevel()}\n");

            // Display menu options
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");

            // Get user choice
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            // Create new goal
            if (choice == "1")
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("    1. Simple Goal");
                Console.WriteLine("    2. Eternal Goal");
                Console.WriteLine("    3. Checklist Goal");

                Console.Write("Which type of goal would you like to create? ");
                string type = Console.ReadLine();

                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();

                Console.Write("What is a short description of it? ");
                string desc = Console.ReadLine();

                // Validate points input
                int points;
                Console.Write("What is the amount of points associated with this goal? ");
                while (!int.TryParse(Console.ReadLine(), out points))
                {
                    Console.Write("Please enter a valid number: ");
                }

                // Create appropriate goal type
                if (type == "1")
                {
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                }
                else if (type == "2")
                {
                    manager.AddGoal(new EternalGoal(name, desc, points));
                }
                else if (type == "3")
                {
                    int target;
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    while (!int.TryParse(Console.ReadLine(), out target))
                    {
                        Console.Write("Please enter a valid number: ");
                    }

                    int bonus;
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    while (!int.TryParse(Console.ReadLine(), out bonus))
                    {
                        Console.Write("Please enter a valid number: ");
                    }

                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                }
            }

            // Display all goals
            else if (choice == "2")
            {
                manager.DisplayGoals();
            }

            // Save goals to file
            else if (choice == "3")
            {
                Console.Write("What is the filename for the goal file? ");
                string file = Console.ReadLine();

                // Validate file type
                if (!file.EndsWith(".txt"))
                {
                    Console.WriteLine("File must end with .txt");
                }
                else
                {
                    manager.Save(file);
                }
            }

            // Load goals from file
            else if (choice == "4")
            {
                Console.Write("What is the filename for the goal file? ");
                manager.Load(Console.ReadLine());
            }

            // Record goal completion
            else if (choice == "5")
            {
                manager.DisplayGoalNames();

                int index;
                Console.Write("Which goal did you accomplish? ");
                while (!int.TryParse(Console.ReadLine(), out index))
                {
                    Console.Write("Please enter a valid number: ");
                }

                manager.RecordEvent(index - 1);
            }

            // Exit program
            else if (choice == "6")
            {
                running = false;
            }
        }
    }
}