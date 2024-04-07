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
        Console.WriteLine("Enter your answer:");
        string playerAnswer = Console.ReadLine();

        if (playerAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Congratulations! You solved the puzzle!");
        }
        else
        {
            Console.WriteLine("Incorrect answer. Try again!");
        }
    }
}
