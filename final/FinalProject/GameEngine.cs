using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;


public class GameEngine
{
    private Protagonist protagonist;
    private List<AdventureWorld> worlds = new List<AdventureWorld>();
    private DialogueSystem dialogueSystem = new DialogueSystem();

        public GameEngine(Protagonist protagonist)
    {
        this.protagonist = protagonist;
    }

        public void SetupWorlds()
    {
        //Algebraic Dungeons
        AdventureWorld algebraicDungeons = new AdventureWorld("Algebraic Dungeons", "A world where math equations guard every path.");
        algebraicDungeons.AddChallenge(new PencilSwordCombat("A wild equation appears!", 50, 10));
        algebraicDungeons.AddNPC(new NPC("Math Wizard", "Solve my riddles to pass."));
        worlds.Add(algebraicDungeons);
       // Literary Labyrinth
        AdventureWorld literaryLabyrinth = new AdventureWorld("Literary Labyrinth", "A maze filled with classic literature puzzles.");
        // Add challenges and NPCs for Literary Labyrinth if needed
        worlds.Add(literaryLabyrinth);

        // History Dungeon
        AdventureWorld historyDungeon = new AdventureWorld("History Dungeon", "A world where history questions guard every path.");
        // Add challenges and NPCs for History Dungeon if needed
        worlds.Add(historyDungeon);

        // Science Fiction World
        AdventureWorld scienceFictionWorld = new AdventureWorld("Science Fiction World", "A world where science fiction becomes reality.");
        // Add challenges and NPCs for Science Fiction World if needed
        worlds.Add(scienceFictionWorld);

        // Add other worlds for each subject
    }


    public void StartAdventure()
    {
        Console.WriteLine("Welcome to the Academy of Enlightened Scholars. Your journey begins amidst a great curse...");
        // Initial meeting with the Mentor Mage
        NPC mentorMage = new NPC("Mentor Mage", "The Academy needs your help. The subjects have come alive, each becoming a challenge of its own.");
        mentorMage.Speak();
        // The mentor provides the first quest
        protagonist.AcceptQuest(new Quest("Defeat the Math Monster", "Solve the puzzles of the Algebraic Dungeons."));
    }

    public void Update()
    {
        // This method would be called in a loop to update the game state
        // Example: Check if the player has entered a new world, encountered an NPC, or found an item

        // Pseudo-code:
        // if (playerEntersNewWorld) {
        //     HandleWorldEntry(currentWorld);
        // }

        // This could also handle time-based events or responses to player actions
    }
        public void EncounterSubjectGuardian(Protagonist protagonist, string worldName)
    {
        AdventureWorld world = worlds.FirstOrDefault(w => w.Name == worldName);
        if(world != null)
        {
            // Example of encountering the Math Monster
            Console.WriteLine($"You are facing the guardian of {world.Name}.");
            // Battle or puzzle mechanics go here
        }
    }
    public void ProgressStory(Protagonist protagonist)
    {
        // As the player completes quests and interacts with the world, the story progresses
        // This method checks for such conditions and updates the game accordingly

        if (protagonist.ActiveQuests.Any(q => q.Title == "Find the Ancient Book"))
        {
            // Example of triggering a special dialogue upon completing a quest
            NPC npc = new NPC("The Wise Old Librarian", "Thank you for finding the Ancient Book!");
            dialogueSystem.StartDialogue(npc, protagonist);
            protagonist.CompleteQuest("Find the Ancient Book");
            // Perhaps this unlocks a new world, provides a key item, or grants a special ability
        }

        // More conditions for story progression here...
    }

    public bool IsGameOver()
    {
        // Determine if game over conditions are met
        // This could be based on the protagonist's health, completion of the main quest, etc.

        if (!protagonist.IsAlive())
        {
            Console.WriteLine("Alas, your journey has come to an untimely end.");
            return true;
        }

        // Example: Check if the main quest has been completed
        if (protagonist.QuestLog.All(q => q.IsCompleted))
        {
            Console.WriteLine("Congratulations! You have mastered all the challenges and restored peace to the Academy.");
            return true;
        }

        return false;
    }

    // Additional methods for handling world entry, NPC interactions, and item discoveries could be added here
    public Protagonist LoadGameState(string filePath)
    {
        try
        {
            // Read the JSON string from the file
            var jsonString = File.ReadAllText(filePath);
            // Convert the JSON string back to a Protagonist object
            var protagonist = JsonSerializer.Deserialize<Protagonist>(jsonString);
            Console.WriteLine("Game loaded successfully.");
            return protagonist;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the game: {ex.Message}");
            return null; // Return null or a new Protagonist as a fallback
        }
    }

}
