using System;
using System.Collections.Generic;
using System.Linq;
using MyGame.Engine;
using MyGame.Characters;

public class AdventureWorld {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Challenge> Challenges { get; private set; } = new List<Challenge>();
    private List<NPC> npcs = new List<NPC>();

    public AdventureWorld(string name, string description) {
        Name = name;
        Description = description;
    }

    public void AddNPC(NPC npc) {
        npcs.Add(npc);
    }

    public void AddChallenge(Challenge challenge) {
        Challenges.Add(challenge);
    }

    // Sequentially execute challenges
    public void ChallengePlayerSequentially(Protagonist protagonist) {
        foreach (var challenge in Challenges) {
            Console.WriteLine($"You encounter a challenge: {challenge.Description}");
            bool success = challenge.StartChallenge(protagonist);
            if (!success) {
                Console.WriteLine("You did not succeed in the challenge. Try again next time.");
                return; // Exit the method if the challenge is not completed successfully
            }
            Console.WriteLine("You have successfully overcome the challenge!");
        }
        // Interact with NPCs after completing all challenges
        InteractWithNPCs(protagonist);
    }

    public bool IsCompleted() {
        return Challenges.All(c => c.IsCompleted);
    }

    public void InteractWithNPCs(Protagonist protagonist) {
        foreach (var npc in npcs) {
            npc.Interact(protagonist); // Assuming NPC has an Interact method
        }
    }
}
