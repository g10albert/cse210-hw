public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Overrides RecordEvent to mark the goal complete and return points
    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            // The points are returned to the GoalManager to update the score
            Console.WriteLine($"Congratulations! You have completed '{_shortName}' and earned {_points} points!");
        }
        else
        {
            Console.WriteLine($"Goal '{_shortName}' is already complete.");
        }
    }

    // Overrides IsComplete to check the state
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Overrides GetDetailsString to display completion status
    public override string GetDetailsString()
    {
        string completionStatus = IsComplete() ? "[X]" : "[ ]";
        return $"{completionStatus} {_shortName} ({_description})";
    }

    // Overrides GetStringRepresentation for saving (Type:Name,Description,Points,IsComplete)
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
    
    // Additional constructor for loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }
}