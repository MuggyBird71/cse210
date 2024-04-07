public abstract class Challenge
{
    public string Description { get; set; }

    protected Challenge(string description)
    {
        Description = description;
    }

    public abstract void StartChallenge(Protagonist protagonist);
}
