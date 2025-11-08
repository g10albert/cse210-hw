public class Journal
{

  public List<Entry> _entries = new List<Entry>();


  public void AddEntry(string prompt)
  {
    Entry newEntry = new Entry();

    newEntry._promptText = prompt;
    newEntry._date = DateTime.Now.ToShortDateString();
    newEntry._entryText = Console.ReadLine();

    _entries.Add(newEntry);

  }

  public void DisplayAll()
  {
    foreach (Entry entry in _entries)
    {
      entry.Display();
    }
  }

  public void LoadFromFile(string filename)
  {
    string[] entries = System.IO.File.ReadAllLines(filename);

    foreach (string entry in entries)
    {
      string[] parts = entry.Split("|");

      Entry loadedEntry = new Entry();

      loadedEntry._date = parts[0].Trim();
      loadedEntry._promptText = parts[1].Trim();
      loadedEntry._entryText = parts[2].Trim();

      _entries.Add(loadedEntry);
    }
  }

  public void SaveToFile(string filename)
  {

    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        outputFile.WriteLine($"Date: {entry._date}| Prompt: {entry._promptText}| {entry._entryText}");
      }
    }

  }
}