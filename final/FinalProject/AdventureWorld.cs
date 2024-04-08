using System;
using System.Collections.Generic;

public class AdventureWorld
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    private List<Challenge> challenges = new List<Challenge>();
    private List<NPC> npcs = new List<NPC>();

    public AdventureWorld(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddNPC(NPC npc)
    {
        npcs.Add(npc);
    }

    public void AddChallenge(Challenge challenge)
    {
        challenges.Add(challenge);
    }

    public void ChallengePlayer(Protagonist protagonist)
    {
        // World challenge logic
    }

    public bool IsCompleted()
    {
        // Check completion status
        return true;
    }
}
