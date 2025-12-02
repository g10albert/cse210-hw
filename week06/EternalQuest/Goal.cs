public abstract class Goal
{
    // Encapsulated attributes
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract method to be implemented by derived classes (Polymorphism)
    public abstract void RecordEvent();

    // Virtual method to be overridden if needed
    public virtual bool IsComplete()
    {
        return false;
    }

    // Abstract method to be implemented by derived classes
    public abstract string GetDetailsString();

    // Getter for the short name
    public string GetShortName()
    {
        return _shortName;
    }

    // Virtual method to get the string representation for saving/loading
    public abstract string GetStringRepresentation();
}