public class ListingActivity : ActivityBase
{
    public ListingActivity() : base("Listing") { }

    public override void PerformActivity()
    {
        InitializeActivity();
        // Example listing logic
        Console.WriteLine("List your goals for this month...");
        AnimationUtils.Countdown(Duration);
        CompleteActivity();
    }
}
