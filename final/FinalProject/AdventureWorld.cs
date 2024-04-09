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
            foreach (var challenge in challenges)
        {
            Console.WriteLine($"You encounter a challenge: {challenge.Description}");
            bool success = challenge.StartChallenge(protagonist);
            if (success)
            {
                Console.WriteLine("You have successfully overcome the challenge!");
            }
            else
            {
                Console.WriteLine("You did not succeed in the challenge. Try again next time.");
                break; // This could be removed if you want the player to continue through challenges regardless of success
            }
        }
    }

    public bool IsCompleted()
    {
        // The world is considered completed if all challenges are completed
        return challenges.All(c => c.IsCompleted);
    }

}
