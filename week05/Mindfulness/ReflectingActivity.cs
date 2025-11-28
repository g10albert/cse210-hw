using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class ReflectingActivity : Activity
{
  private List<string> _prompts;
  private List<string> _questions;

  public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.", 0)
  {
    _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
        };

    _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn about yourself through this experience?",
        };
  }

  public override void Run()
  {
    DisplayStartingMessage();

    DisplayPrompt();
    Console.WriteLine("\nNow, consider each of the following questions as they relate to this experience.");
    Console.Write("When you have something in mind, press Enter to continue.");
    Console.ReadLine();

    DisplayQuestions();

    DisplayEndingMessage();
  }

  public string GetRandomPrompt()
  {
    Random rand = new Random();
    int index = rand.Next(_prompts.Count);
    return _prompts[index];
  }

  public string GetRandomQuestion()
  {
    Random rand = new Random();
    int index = rand.Next(_questions.Count);
    return _questions[index];
  }

  public void DisplayPrompt()
  {
    Console.WriteLine($"\n Prompt \n{GetRandomPrompt()}\n");
  }

  public void DisplayQuestions()
  {
    DateTime endTime = DateTime.Now.AddSeconds(_duration);

    Console.WriteLine("Begin reflecting on the questions...");

    List<string> availableQuestions = new List<string>(_questions);
    Random rand = new Random();

    while (DateTime.Now < endTime)
    {
      if (availableQuestions.Count == 0)
      {
        availableQuestions = new List<string>(_questions);
      }

      int index = rand.Next(availableQuestions.Count);
      string question = availableQuestions[index];
      availableQuestions.RemoveAt(index);

      Console.WriteLine($"\n> {question}");
      ShowSpinner(5);

      if (DateTime.Now >= endTime) break;
    }
  }
}