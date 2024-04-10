using System;

namespace DailyScripture
{
    class Program
    {
        
        static void Main()
        {
            Scripture scripture = new Scripture("3 Nephi ", 5, 13, "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life. ");
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // Handle or ignore the exception when the console is not available.
            }

            scripture.Display(); 
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                if (!scripture.HideRandomWord())
                {
                    Console.WriteLine("\nYou got this, you memorized the scripture!!");
                    break;
                }

                try
                {
                    Console.Clear();
                }
                catch (System.IO.IOException)
                {
                    // Handle or ignore the exception when the console is not available.
                }
                scripture.Display();
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            }
        }
    }
}