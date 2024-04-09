public abstract class Challenge
{
    public string Description { get; private set; }
    public bool IsCompleted { get; protected set; }

    protected Challenge(string description)
    {
        Description = description;
        IsCompleted = false;
    }

    // Ensure this method returns a bool
    public abstract bool StartChallenge(Protagonist protagonist);
}
