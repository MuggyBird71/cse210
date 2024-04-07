using System;
using System.Collections.Generic;

public class AdventureWorld
{
    public string Location { get; set; }
    private List<Challenge> challenges = new List<Challenge>();
    private List<NPC> npcs = new List<NPC>();

    public AdventureWorld(string location)
    {
        Location = location;
    }

    public void AddChallenge(Challenge challenge)
    {
        challenges.Add(challenge);
    }

    public void AddNPC(NPC npc)
    {
        npcs.Add(npc);
    }

    public void InteractWithNPC(string npcName)
    {
        NPC npc = NPC.FindNPCByName(npcs, npcName);
        if (npc != null)
        {
            npc.Speak();
            // Additional interaction logic with the NPC
        }
        else
        {
            Console.WriteLine($"There is no NPC named {npcName} in this location.");
        }
    }
}
