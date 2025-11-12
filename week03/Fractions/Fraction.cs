using System.Reflection.Metadata.Ecma335;

public class Fraction
{
  private int _top;
  private int _bottom;

  public int GetTop()
  {
    int top = _top;
    return top;
  }

  public int GetBottom()
  {
    int bottom = _bottom;
    return bottom;
  }

  public void SetTop(int top)
  {
    int _top = top;
  }

  public void SetBottom(int bottom)
  {
    int _bottom = bottom;
  }

  public string GetFractionString()
  {
    string fraction = $"{_top}/{_bottom}";
    return fraction;
  }

  public double GetDecimalValue()
  {
    double fraction = (double)_top / (double)_bottom;
    return fraction;
  }
  public Fraction()
  {
    _top = 1;
    _bottom = 1;
  }

  public Fraction(int top)
  {
    _top = top;
    _bottom = 1;
  }
  
  public Fraction(int top, int bottom)
  {
    _top = top;
    _bottom = bottom;
  }
}