public class MenuSystem
{
    public void DisplayMenu()
    {
        Console.WriteLine("\nSelect an activity:");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
    }

    public void SelectActivity(int choice)
    {
        ActivityBase activity = choice switch
        {
            1 => new BreathingActivity(),
            2 => new ReflectionActivity(),
            3 => new ListingActivity(),
            _ => null,
        };

        activity?.PerformActivity();
    }
}
