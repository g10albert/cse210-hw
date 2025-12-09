public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;

    public Swimming(string date, int minutes, int laps) 
        : base(date, minutes, "Swimming")
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * LapLengthMeters) / 1000.0;
    }
}