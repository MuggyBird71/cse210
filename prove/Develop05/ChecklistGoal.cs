public class ChecklistGoal : GoalBase
{
    public int CompletionCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string title, string description, int points, int completionCount, int bonusPoints)
        : base(title, description, points)
    {
        CompletionCount = completionCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void MarkComplete()
    {
        CurrentCount++;
        if (CurrentCount >= CompletionCount)
        {
            base.MarkComplete();
            Console.WriteLine($"Congratulations! You've earned {BonusPoints} bonus points!");
        }
    }
}
