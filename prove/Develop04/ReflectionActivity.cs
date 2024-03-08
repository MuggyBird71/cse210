public class ReflectionActivity : ActivityBase
{
    public ReflectionActivity() : base("Reflection") { }

    public override void PerformActivity()
    {
        InitializeActivity();
        // Example reflection logic
        Console.WriteLine("Reflect on your recent achievements...");
        AnimationUtils.Countdown(Duration);
        CompleteActivity();
    }
}
