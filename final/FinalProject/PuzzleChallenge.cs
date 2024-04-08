using System;

public class PuzzleChallenge : Challenge
{
    private string answer;

    public PuzzleChallenge(string description, string answer) : base(description)
    {
        this.answer = answer;
    }

    public override void StartChallenge(Protagonist protagonist)
    {
        Console.WriteLine(Description);
        // Puzzle logic
    }
}
