using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> words;

    public Scripture(Reference reference, string scriptureText)
    {
        Reference = reference;
        words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayScripture()
    {
        Console.WriteLine(Reference.ToString());
        Console.WriteLine(string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Text)));
    }

    public void HideRandomWords(int numberOfWordsToHide)
    {
        Random random = new Random();
        var visibleWords = words.Where(w => !w.IsHidden).ToList();
        if (!visibleWords.Any()) return; // Avoid infinite loop if all words are hidden

        for (int i = 0; i < numberOfWordsToHide && visibleWords.Count > 0; i++)
        {
            int indexToHide = random.Next(visibleWords.Count);
            visibleWords[indexToHide].IsHidden = true;
            visibleWords.RemoveAt(indexToHide); // Remove the word from consideration
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}
