using System;
using System.Threading;

public class BreathingActivity : Activity
{
  public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through controlled breathing patterns.", 0) { }

  public override void Run()
  {
    DisplayStartingMessage();

    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(_duration);

    while (DateTime.Now < endTime)
    {
      Console.Write("\n\nBreath in...");
      ShowCountDown(4);

      if (DateTime.Now >= endTime) break;

      Console.Write("Breath out...");
      ShowCountDown(6);
    }

    DisplayEndingMessage();
  }
}