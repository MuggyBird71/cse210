public abstract class GoalBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    protected GoalBase(string title, string description, int points)
    {
        Title = title;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public virtual void MarkComplete()
    {
        IsComplete = true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Title}: {Description} - Points: {Points}, Complete: {IsComplete}");
    }
}
