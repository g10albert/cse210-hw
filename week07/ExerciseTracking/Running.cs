public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distanceKm) 
        : base(date, minutes, "Running")
    {
        _distance = distanceKm;
    }

    public override double GetDistance()
    {
        return _distance;
    }
}