using System;
using MyGame.Engine;
using MyGame.Characters;
public class PuzzleChallenge : Challenge
{
    private string answer;

    public PuzzleChallenge(string description, string answer) : base(description)
    {
        this.answer = answer;
    }

    public override bool StartChallenge(Protagonist protagonist)
    {
        Console.WriteLine(Description);
        Console.Write("Your answer: ");
        string playerAnswer = Console.ReadLine();

        if (playerAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Correct! You have successfully solved the puzzle.");
            IsCompleted = true; // Mark this challenge as completed
            return true; // Indicate success
        }
        else
        {
            Console.WriteLine("That's incorrect. Perhaps you'll figure it out next time.");
            // Consider allowing retries or providing hints depending on your game design
            return false; // Indicate failure
        }
    }
}
