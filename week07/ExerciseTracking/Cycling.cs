public class Cycling : Activity
{
  private double _speed; 

  public Cycling(string date, int minutes, double speedKph)
      : base(date, minutes, "Cycling")
  {
    _speed = speedKph;
  }

  public override double GetDistance()
  {
    return (_speed / 60) * GetMinutes();
  }

  public override double GetSpeed()
  {
    return _speed;
  }

}