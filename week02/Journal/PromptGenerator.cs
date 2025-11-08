using System;
using System.Collections.Generic;

public class PromptGenerator
{
  public List<string> _entries = new List<string>();
  public string GetRandomPrompt()
  {
    Random randomGenerator = new Random();
    int randomEntry = randomGenerator.Next(0, _entries.Count);
    return _entries[randomEntry];
  }
}