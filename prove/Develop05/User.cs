using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public int Score { get; set; }
    public List<string> Achievements { get; set; }

    public User(string name)
    {
        Name = name;
        Score = 0;
        Achievements = new List<string>();
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public void AddAchievement(string achievement)
    {
        Achievements.Add(achievement);
    }
}
