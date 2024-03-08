public static class AnimationUtils
{
    public static void Countdown(int duration)
    {
        while (duration > 0)
        {
            Console.Write(duration + " ");
            Thread.Sleep(1000);
            duration--;
        }
        Console.WriteLine();
    }

    public static void SimpleSpinner(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
