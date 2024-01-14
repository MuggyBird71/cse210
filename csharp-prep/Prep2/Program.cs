using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What was your grade percentage? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        string letter = "";

        if (number >= 90)
        {
            letter = "A";
        }

        else if (number >= 80 && number < 90)
        {
            letter = "B";
        }

        else if (number >= 70 && number < 80)
        {
            letter = "C";
        }

        else if (number >= 60 && number < 70)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (number >= 70)
        {
            Console.WriteLine("You Passed!");
        }

        else
        {
            Console.WriteLine("You failed the class.");
        }
    }
}