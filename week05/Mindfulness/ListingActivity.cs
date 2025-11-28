using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
  private int _count;
  private List<string> _prompts;

  public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
  {
    _count = 0;
    _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are some of your personal heroes?",
            "What are things you're grateful for today?"
        };
  }

  public override void Run()
  {
    DisplayStartingMessage();

    string prompt = GetRandomPrompt();
    Console.WriteLine($"\nPrompt: {prompt}");
    Console.WriteLine($"Begin listing now! You have {_duration} seconds.");
    ShowCountDown(3);

    List<string> userList = GetListFromUser(_duration);
    _count = userList.Count;

    Console.WriteLine($"\nYou listed **{_count}** items!");

    DisplayEndingMessage();
  }

  public string GetRandomPrompt()
  {
    Random rand = new Random();
    int index = rand.Next(_prompts.Count);
    return _prompts[index];
  }

  public List<string> GetListFromUser(int duration)
  {
    List<string> userList = new List<string>();
    DateTime endTime = DateTime.Now.AddSeconds(duration);

    while (DateTime.Now < endTime)
    {
      Console.Write("> ");
      string input = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(input))
      {
        userList.Add(input.Trim());
      }

      if (DateTime.Now >= endTime) break;
    }
    return userList;
  }
}