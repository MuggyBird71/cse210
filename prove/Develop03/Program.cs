using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

        // Attempt to load scriptures from a file (ensure the file path is correct)
        string filePath = "scriptures.txt"; // Update this path as necessary
        scriptureLibrary.LoadScripturesFromFile(filePath);

        // If no scriptures are loaded (file not found or empty), you could add some default scriptures
        if (scriptureLibrary.IsEmpty())
        {
            // Add default scripture if library is empty
            scriptureLibrary.AddScripture(new Reference("John", 3, 16), "For God so loved the world...");
            // Add more default scriptures as needed
        }

        // Main loop
        bool exitProgram = false;
        while (!exitProgram)
        {
            Scripture scripture = scriptureLibrary.GetRandomScripture();
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\nPress enter to hide words, type 'quit' to exit.");

            string userInput = Console.ReadLine();
            if (userInput.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                exitProgram = true;
            }
            else
            {
                // Hide one word (or more, based on your logic) and redisplay
                scripture.HideRandomWords(1); // Adjust the number of words to hide as desired
                Console.Clear();
                scripture.DisplayScripture();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Press enter to continue with a new scripture or type 'quit' to exit.");
                    if (Console.ReadLine().Equals("quit", StringComparison.OrdinalIgnoreCase))
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}
