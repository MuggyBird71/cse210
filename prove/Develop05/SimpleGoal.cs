public class SimpleGoal : GoalBase
{
    public SimpleGoal(string title, string description, int points) : base(title, description, points)
    {
    }

    public override void MarkComplete()
    {
        base.MarkComplete();
    }
}
