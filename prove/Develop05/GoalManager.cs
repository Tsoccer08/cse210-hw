using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return _score / 1000;
    }

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayInfo()}");
        }
    }

    public void DisplayGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int oldLevel = _score / 1000;

            int earned = _goals[index].RecordEvent();

            if (earned == -1)
            {
                Console.WriteLine("You have already completed this goal.");
                return;
            }

            _score += earned;

            int newLevel = _score / 1000;

            Console.WriteLine($"Congratulations! You have earned {earned} points!");
            Console.WriteLine($"You now have {_score} points.");

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

    public void Save(string filename)
    {
        if (!filename.EndsWith(".txt"))
        {
            Console.WriteLine("File must end with .txt");
            return;
        }

        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(_score);

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

    public void Load(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);

            _goals.Clear();
            _score = int.Parse(lines[0]);

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