public class UIManager
{
    private readonly GoalManager _goalManager;
    private readonly User _user;
    private readonly StorageManager _storageManager;

    public UIManager(GoalManager goalManager, User user, StorageManager storageManager)
    {
        _goalManager = goalManager;
        _user = user;
        _storageManager = storageManager;
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Add Goal");
        Console.WriteLine("2. Complete Goal");
        Console.WriteLine("3. Display Goals");
        Console.WriteLine("4. Show Achievements");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }

    public void InputGoalDetails()
    {
        Console.WriteLine("\nAdd New Goal");
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        // For simplicity, adding as a SimpleGoal
        var goal = new SimpleGoal(title, description, points);
        _goalManager.AddGoal(goal);

        Console.WriteLine("Goal added successfully.");
    }

    public void CompleteGoal()
    {
        Console.WriteLine("\nComplete a Goal");
        Console.Write("Enter the title of the goal to mark as complete: ");
        string title = Console.ReadLine();
        
        _goalManager.CompleteGoal(title);
        Console.WriteLine("Goal marked as complete.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        _goalManager.DisplayGoals();
    }

    public void ShowAchievements()
    {
        Console.WriteLine("\nAchievements:");
        foreach (var achievement in _user.Achievements)
        {
            Console.WriteLine(achievement);
        }
    }
}
