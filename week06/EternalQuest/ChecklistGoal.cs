public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Overrides RecordEvent to track progress and award bonus upon completion
    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            Console.Write($"Congratulations! You have recorded '{_shortName}' and earned {_points} points!");

            // Check for bonus
            if (IsComplete())
            {
                Console.WriteLine($" You have reached the target! You receive a bonus of {_bonus} points!");
            }
            else
            {
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Goal '{_shortName}' is already complete.");
        }
    }

    // Overrides IsComplete to check if the target has been reached
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Overrides GetDetailsString to show progress
    public override string GetDetailsString()
    {
        string completionStatus = IsComplete() ? "[X]" : "[ ]";
        return $"{completionStatus} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Overrides GetStringRepresentation for saving (Type:Name,Description,Points,Target,Bonus,AmountCompleted)
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
    
    // Additional constructor for loading from file
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // Getter for the bonus
    public int GetBonus()
    {
        return _bonus;
    }
    
    // Getter for points (used when calculating the total points from a record event)
    public int GetPoints()
    {
        return _points;
    }
}