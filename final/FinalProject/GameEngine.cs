using System.Collections.Generic;

public class GameEngine
{
    private Protagonist protagonist;
    private List<AdventureWorld> worlds = new List<AdventureWorld>();

    public GameEngine(Protagonist protagonist)
    {
        this.protagonist = protagonist;
    }

    public void SetupWorlds()
    {
        // Create AdventureWorld instances for different locations
        AdventureWorld forestWorld = new AdventureWorld("Enchanted Forest");
        AdventureWorld caveWorld = new AdventureWorld("Dark Cave");

        // Populate each world with challenges and NPCs
        PopulateForestWorld(forestWorld);
        PopulateCaveWorld(caveWorld);

        // Add the worlds to the game engine
        worlds.Add(forestWorld);
        worlds.Add(caveWorld);
    }

    private void PopulateForestWorld(AdventureWorld forestWorld)
    {
        // Add challenges to the forest world
        forestWorld.AddChallenge(new PencilSwordCombat("Defeat the Goblin", 30, 15));
        forestWorld.AddChallenge(new PuzzleChallenge("Solve the Riddle", "answer"));

        // Add NPCs to the forest world
        NPC forestNPC = new NPC("Forest Guide", "Welcome to the Enchanted Forest! Beware of the goblins lurking within.");
        forestWorld.AddNPC(forestNPC);
    }

    private void PopulateCaveWorld(AdventureWorld caveWorld)
    {
        // Add challenges to the cave world
        caveWorld.AddChallenge(new PencilSwordCombat("Confront the Cave Troll", 50, 20));
        caveWorld.AddChallenge(new PuzzleChallenge("Unlock the Ancient Door", "password"));

        // Add NPCs to the cave world
        NPC caveNPC = new NPC("Cave Dweller", "Only the bravest adventurers dare to explore the depths of this cave.");
        caveWorld.AddNPC(caveNPC);
    }

    public void StartAdventure()
    {
        // Navigate through worlds and initiate challenges
    }
}
