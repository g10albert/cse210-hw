using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }


    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have **{_score} points**!");
    }

    public void ListGoalDetails()
    {
        if (!_goals.Any())
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }

        Console.WriteLine("\n**Your Goals:**");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalNames()
    {
        if (!_goals.Any())
        {
            Console.WriteLine("\nNo goals to list.");
            return;
        }

        Console.WriteLine("\n**The goals are:**");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void CreateGoal(string goalType)
    {
        Console.WriteLine($"\nCreating a new **{goalType}** Goal:");
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points;
        while (true)
        {
            Console.Write("What is the amount of points associated with this goal? ");
            if (int.TryParse(Console.ReadLine(), out points) && points >= 0) break;
            Console.WriteLine("Invalid input. Please enter a positive whole number for points.");
        }

        Goal newGoal = null;
        if (goalType == "Simple")
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (goalType == "Eternal")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (goalType == "Checklist")
        {
            int target;
            while (true)
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (int.TryParse(Console.ReadLine(), out target) && target > 0) break;
                Console.WriteLine("Invalid input. Please enter a positive whole number for the target.");
            }

            int bonus;
            while (true)
            {
                Console.Write("What is the bonus amount for completing it? ");
                if (int.TryParse(Console.ReadLine(), out bonus) && bonus >= 0) break;
                Console.WriteLine("Invalid input. Please enter a positive whole number for the bonus.");
            }

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"\nGoal '{name}' successfully created!");
        }
    }

    public void RecordEvent(int index)
    {
        try
        {
            Goal goal = _goals[index - 1];

            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;

            if (pointsEarned > 0)
            {
                Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");
            }
            else
            {
                Console.WriteLine("\nEvent recorded, but no additional points were earned (Goal already complete).");
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("\nError: Invalid goal number.");
        }
    }

    public void SaveGoals(string filename = "goals.txt")
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals successfully saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving goals: {ex.Message}");
        }
    }

    public void LoadGoals(string filename = "goals.txt")
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\nNo save file found. Starting with 0 points and no goals.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length > 0 && int.TryParse(lines[0], out int score))
            {
                _score = score;
            }

            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                string goalType = parts[0];
                
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal newGoal = null;

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);
                    newGoal = new SimpleGoal(name, description, points, isComplete);
                }
                else if (goalType == "EternalGoal")
                {
                    newGoal = new EternalGoal(name, description, points);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                    newGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                }
                
                if (newGoal != null)
                {
                    _goals.Add(newGoal);
                }
            }
            Console.WriteLine($"\nGoals successfully loaded from {filename}. Current score: {_score}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading goals. Check file format. Error: {ex.Message}");
            _score = 0;
            _goals.Clear();
        }
    }
}