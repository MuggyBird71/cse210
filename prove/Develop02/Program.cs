using System;

class Program
{
    static JournalManager journalManager = new JournalManager();
    static FileHandler fileHandler = new FileHandler();
    static PromptGenerator promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            ShowMenu();
            string option = Console.ReadLine();
            running = ExecuteOption(option);
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }
    
    static bool ExecuteOption(string option)
    {
        switch (option)
        {
           case "1":
                WriteNewEntry();
                break;
            case "2":
                journalManager.DisplayEntries();
                break;
            case "3":
                SaveJournal();
                break;
            case "4":
                LoadJournal();
                break;
            case "5":
                return false;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
        return true;
    }
   
    static void WriteNewEntry()
    {
        string prompt = promptGenerator.GeneratePrompt();
        Console.WriteLine($"Today's prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        JournalEntry entry = new JournalEntry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response);
        journalManager.AddEntry(entry);
    }

    static void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        fileHandler.SaveJournal(filename, journalManager.Entries);
    }

    static void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        var entries = fileHandler.LoadJournal(filename);
        journalManager.Entries = entries;
    }
}