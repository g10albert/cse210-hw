using System.Collections.Generic;

public class Resume
{
  public string _name = "";
  public List<Job> _jobs = new List<Job>();

  public void Display()
  {
    Console.WriteLine($"Nmae: {_name}");
    Console.WriteLine("Jobs:");
    foreach (Job a in _jobs)
    {
      Console.WriteLine($"{a._company}");
    }
  }
}