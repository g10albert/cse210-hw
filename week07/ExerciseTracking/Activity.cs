using System;

public abstract class Activity
{
  private string _date;
  private int _minutes;
  private string _activityType;


  public Activity(string date, int minutes, string activityType)
  {
    _date = date;
    _minutes = minutes;
    _activityType = activityType;
  }

  public int GetMinutes()
  {
    return _minutes;
  }

  public abstract double GetDistance();
  public virtual double GetSpeed()
  {
    if (_minutes == 0 || GetDistance() == 0)
    {
      return 0;
    }
    return (GetDistance() / _minutes) * 60;
  }
  public virtual double GetPace()
  {

    if (GetDistance() == 0)
    {

      return 0;
    }
    return (double)_minutes / GetDistance();
  }
  public string GetSummary()
  {
    double distance = Math.Round(GetDistance(), 1);
    double speed = Math.Round(GetSpeed(), 1);
    double pace = Math.Round(GetPace(), 2);

    return $"{_date} {_activityType} ({_minutes} min): " + $"Distance {distance} km, " + $"Speed: {speed} kph, " + $"Pace: {pace} min per km";
  }
}