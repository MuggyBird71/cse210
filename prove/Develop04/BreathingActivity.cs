public class BreathingActivity : ActivityBase
{
    public BreathingActivity() : base("Breathing") { }

    public override void PerformActivity()
    {
        InitializeActivity();
        int iterations = Duration / 6; // Adjust based on breathe in/out duration
        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine("Breathe in...");
            AnimationUtils.Countdown(3);
            Console.WriteLine("Breathe out...");
            AnimationUtils.Countdown(3);
        }
        CompleteActivity();
    }
}
