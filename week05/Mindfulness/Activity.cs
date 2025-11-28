using System;
using System.Threading;

public abstract class Activity
{
  protected string _name;
  protected string _description;
  protected int _duration;

  public Activity(string name, string description, int duration)
  {
    _name = name;
    _description = description;
    _duration = duration;
  }

  public abstract void Run();

  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Starting: {_name}");
    Console.WriteLine($"Description: {_description}");
    Console.Write("How long, in seconds, would you like for your session? ");
  }

  public void DisplayEndingMessage()
  {
    Console.WriteLine("\nGreat job! You have completed the session.");
    Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
    ShowSpinner(3);
    Console.WriteLine("Ending: Activity Complete");
  }

  public void ShowSpinner(int seconds)
  {
    char[] spinner = { '|', '/', '-', '\\' };
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(seconds);
    int i = 0;

    Console.Write(" ");
    while (DateTime.Now < endTime)
    {
      Console.Write(spinner[i % spinner.Length]);
      Thread.Sleep(250);
      Console.Write("\b");

      i++;
    }
  }

  public void ShowCountDown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write($"Start in: {i}");
      Thread.Sleep(1000);
      Console.Write("\r" + new string(' ', 15) + "\r");
    }
  }
}