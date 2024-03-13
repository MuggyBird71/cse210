public class EternalGoal : GoalBase
{
    public EternalGoal(string title, string description, int points) : base(title, description, points)
    {
    }

    public override void MarkComplete()
    {
        // Special handling for eternal goals
        Console.WriteLine("Eternal goal acknowledged. Keep going!");
    }
}
