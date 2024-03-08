public abstract class ActivityBase
{
    public string Name { get; private set; }
    public int Duration { get; private set; }

    protected ActivityBase(string name)
    {
        Name = name;
    }

    public void InitializeActivity()
    {
        Console.WriteLine($"\n{this.Name} Activity");
        Console.WriteLine("Enter duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        AnimationUtils.SimpleSpinner(3);
    }

    public abstract void PerformActivity();

    public void CompleteActivity()
    {
        Console.WriteLine("\nGreat job!");
        AnimationUtils.SimpleSpinner(2);
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        AnimationUtils.SimpleSpinner(2);
    }
}
