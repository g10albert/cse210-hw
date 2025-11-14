using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] rawWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string rawWord in rawWords)
        {
            _words.Add(new Word(rawWord));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> availableWords = _words.Where(word => !word.IsHidden()).ToList();

        int wordsToHide = Math.Min(numberToHide, availableWords.Count);

        if (wordsToHide == 0)
        {
            return; 
        }

        Random random = new Random();
        
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(0, availableWords.Count);
            Word wordToHide = availableWords[randomIndex];
            
            wordToHide.Hide();

            availableWords.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"[{_reference.GetDisplayText()}] ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}