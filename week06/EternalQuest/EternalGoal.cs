public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        // Eternal goals are never complete, so no extra state variable is needed
    }

    // Overrides RecordEvent to always award points
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have recorded '{_shortName}' and earned {_points} points!");
    }

    // Does not override IsComplete as it always returns false from the base class

    // Overrides GetDetailsString to display details
    public override string GetDetailsString()
    {
        // Eternal goals never show [X] because they are never complete
        return $"[ ] {_shortName} ({_description})";
    }

    // Overrides GetStringRepresentation for saving (Type:Name,Description,Points)
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}