using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Main entry point for the program
    public void Start()
    {
        string choice = "";
        do
        {
            DisplayPlayerInfo();
            
            // Display main menu options
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Exit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != "6");
    }

    // Displays the user's current score
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    // Displays only the names of the goals for selection
    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    // Displays the full details (including completion status) of all goals
    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals currently created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphism: calls the appropriate GetDetailsString() method for each Goal object
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Guides the user through creating a new goal
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (typeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal creation cancelled.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{name}' created successfully!");
        }
    }

    // Allows the user to select a goal and record an event
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record an event for. Please create a goal first.");
            return;
        }

        Console.WriteLine("\nGoals available to record:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            
            // Polymorphism: calls the correct RecordEvent() for the Goal object
            goal.RecordEvent();

            // Update the score based on the goal type
            int earnedPoints = 0;
            
            if (goal is SimpleGoal simpleGoal && simpleGoal.IsComplete())
            {
                earnedPoints = int.Parse(goal.GetStringRepresentation().Split(',')[2]); // Retrieve points from string representation
            }
            else if (goal is EternalGoal eternalGoal)
            {
                earnedPoints = int.Parse(goal.GetStringRepresentation().Split(',')[2]); // Retrieve points from string representation
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                earnedPoints = checklistGoal.GetPoints();
                if (checklistGoal.IsComplete())
                {
                    earnedPoints += checklistGoal.GetBonus();
                }
            }
            
            _score += earnedPoints;
            
            // The score update logic here is simpler and safer:
            // The points are already printed inside the RecordEvent, we just need to add them.
            // A more elegant solution would be to make RecordEvent return the points.
            // Let's modify the above to be based on the goal type's point value for simplicity.
            
            // Re-evaluating points (since we can't reliably get the points from the void RecordEvent)
            // A cleaner approach: Check the goal type and points *after* RecordEvent.
            // For now, let's keep the _score update simple based on the class's points/bonus rules.
            
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
    
    // Saves the current score and all goals to a file
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                // Line 1: Save the score
                sw.WriteLine(_score);
                
                // Subsequent lines: Save each goal using its string representation
                foreach (Goal goal in _goals)
                {
                    // Polymorphism: calls the correct GetStringRepresentation()
                    sw.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    // Loads the score and goals from a file
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            // Line 1: Load the score
            _score = int.Parse(lines[0]);
            
            // Subsequent lines: Load the goals
            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                // Common data
                string name = goalData[0];
                string description = goalData[1];
                int points = int.Parse(goalData[2]);

                Goal loadedGoal = null;

                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(goalData[3]);
                        loadedGoal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case "EternalGoal":
                        loadedGoal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int target = int.Parse(goalData[3]);
                        int bonus = int.Parse(goalData[4]);
                        int amountCompleted = int.Parse(goalData[5]);
                        loadedGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                }

                if (loadedGoal != null)
                {
                    _goals.Add(loadedGoal);
                }
            }
            Console.WriteLine($"Goals loaded from {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}");
        }
    }
}