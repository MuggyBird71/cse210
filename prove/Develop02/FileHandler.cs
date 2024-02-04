using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class FileHandler
{
    public void SaveJournal(string filename, List<JournalEntry> entries)
    {
        string json = JsonConvert.SerializeObject(entries);
        File.WriteAllText(filename, json);
    }

    public List<JournalEntry> LoadJournal(string filename)
    {
        string json = File.ReadAllText(filename);
        return JsonConvert.DeserializeObject<List<JournalEntry>>(json);
    }
}
