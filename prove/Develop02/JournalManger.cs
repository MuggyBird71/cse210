using System;
using System.Collections.Generic;

public class JournalManager
{
    public List<JournalEntry> Entries { get; set; } = new List<JournalEntry>();
    
    public void AddEntry(JournalEntry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
        }
    }
}