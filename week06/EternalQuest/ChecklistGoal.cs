public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }
    
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }


    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            int pointsEarned = _points;

            if (_amountCompleted == _target)
            {
                pointsEarned += _bonus;
            }

            return pointsEarned;
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "X" : " ";
        return (
            $"[{status}] {_shortName} ({_description}) - {_points} points " +
            $"(Bonus: {_bonus}) -- Completed {_amountCompleted}/{_target}"
        );
    }

    public override string GetStringRepresentation()
    {
        return (
            $"ChecklistGoal|{_shortName}|{_description}|{_points}|" +
            $"{_target}|{_bonus}|{_amountCompleted}"
        );
    }
}