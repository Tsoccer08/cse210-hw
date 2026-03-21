using System;
using System.Collections.Generic;
using System.IO;

// Handles goal storage, score tracking, and file operations
public class GoalManager
{
    // List to store all goals
    private List<Goal> _goals = new List<Goal>();

    // Tracks total score
    private int _score = 0;

    // Returns current score
    public int GetScore()
    {
        return _score;
    }

    // Calculates level based on score
    public int GetLevel()
    {
        return _score / 1000;
    }

    // Adds a new goal to the list
    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    // Displays full goal details
    public void DisplayGoals()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayInfo()}");
        }
    }

    // Displays only goal names for selection
    public void DisplayGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    // Handles recording a goal event
    public void RecordEvent(int index)
    {
        // Validate index
        if (index >= 0 && index < _goals.Count)
        {
            // Store level before adding points
            int oldLevel = _score / 1000;

            // Attempt to record event
            int earned = _goals[index].RecordEvent();

            // If already completed
            if (earned == -1)
            {
                Console.WriteLine("You have already completed this goal.");
                return;
            }

            // Add earned points
            _score += earned;

            // Calculate new level
            int newLevel = _score / 1000;

            // Display results
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
            Console.WriteLine($"You now have {_score} points.");

            // Check for level up
            if (newLevel > oldLevel)
            {
                Console.WriteLine($"Level Up! You are now level {newLevel}!");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    // Saves goals and score to a file
    public void Save(string filename)
    {
        // Ensure correct file type
        if (!filename.EndsWith(".txt"))
        {
            Console.WriteLine("File must end with .txt");
            return;
        }

        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                // Save score first
                sw.WriteLine(_score);

                // Save each goal
                foreach (Goal g in _goals)
                {
                    sw.WriteLine(g.GetSaveData());
                }
            }
        }
        catch
        {
            Console.WriteLine("Error saving file.");
        }
    }

    // Loads goals and score from a file
    public void Load(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);

            // Clear existing data
            _goals.Clear();

            // Load score
            _score = int.Parse(lines[0]);

            // Recreate each goal
            for (int i = 1; i < lines.Length; i++)
            {
                string[] p = lines[i].Split("|");

                if (p[0] == "SimpleGoal")
                {
                    SimpleGoal g = new SimpleGoal(p[1], p[2], int.Parse(p[3]));
                    g.LoadData(bool.Parse(p[4]));
                    _goals.Add(g);
                }
                else if (p[0] == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
                }
                else if (p[0] == "ChecklistGoal")
                {
                    ChecklistGoal g = new ChecklistGoal(
                        p[1], p[2],
                        int.Parse(p[3]),
                        int.Parse(p[6]),
                        int.Parse(p[4])
                    );

                    g.LoadData(int.Parse(p[5]), int.Parse(p[6]));
                    _goals.Add(g);
                }
            }
        }
        catch
        {
            Console.WriteLine("Error loading file.");
        }
    }
}