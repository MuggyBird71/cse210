using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> scriptures = new List<Scripture>();

    public void AddScripture(Reference reference, string scriptureText)
    {
        scriptures.Add(new Scripture(reference, scriptureText));
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

    public void LoadScripturesFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var referenceParts = parts[0].Split(' ');
            var chapterAndVerse = referenceParts[1].Split(':');
            var verses = chapterAndVerse[1].Split('-');
            var reference = verses.Length == 2
                ? new Reference(referenceParts[0], int.Parse(chapterAndVerse[0]), int.Parse(verses[0]), int.Parse(verses[1]))
                : new Reference(referenceParts[0], int.Parse(chapterAndVerse[0]), int.Parse(verses[0]));
            AddScripture(reference, parts[1]);
        }
    }
public bool IsEmpty()
{
    return scriptures.Count == 0;
}
}
