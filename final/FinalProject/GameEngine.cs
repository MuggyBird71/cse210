using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using MyGame.Characters;
using System.Diagnostics;

namespace MyGame.Engine
{
public class GameEngine
{
    private Protagonist protagonist;
    private List<AdventureWorld> worlds = new List<AdventureWorld>();
    private DialogueSystem dialogueSystem = new DialogueSystem();
    private int currentWorldIndex = 0;
    private int currentChallengeIndex = -1;


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
        literaryLabyrinth.AddChallenge(new PuzzleChallenge("Complete the quote: 'It is a truth universally acknowledged, that a single man in possession of a good fortune, must be in want of a ____.'", "wife"));
        literaryLabyrinth.AddNPC(new NPC("Shakespeare's Ghost", "To be, or not to be, that is the question."));
        worlds.Add(literaryLabyrinth);
        // History Dungeon
        AdventureWorld historyDungeon = new AdventureWorld("History Dungeon", "A world where history questions guard every path.");
        historyDungeon.AddChallenge(new PuzzleChallenge("Who was the first president of the United States?", "George Washington"));
        historyDungeon.AddNPC(new NPC("The Time Traveler", "Careful, actions in the past can change the future!"));
        worlds.Add(historyDungeon);

        // Science Fiction World
        AdventureWorld scienceFictionWorld = new AdventureWorld("Science Fiction World", "A world where science fiction becomes reality.");
        scienceFictionWorld.AddChallenge(new PencilSwordCombat("An alien with a quantum blade appears!", 70, 15));
        scienceFictionWorld.AddNPC(new NPC("Space Charlie Chaplin", "Does this unit have a soul?"));
        worlds.Add(scienceFictionWorld);
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

        public IEnumerable<AdventureWorld> Worlds => worlds.AsReadOnly();

        public void ExploreWorld(int worldIndex)
        {
            if (worldIndex < 0 || worldIndex >= worlds.Count)
            {
                Console.WriteLine("Invalid world selection.");
                return;
            }

            currentWorldIndex = worldIndex;
            currentChallengeIndex = -1; // Reset challenge index for a new world exploration

            var world = worlds[currentWorldIndex];
            Console.WriteLine($"Entering {world.Name}. Let's explore!");

            ProceedToNextChallenge(); // Start with the first challenge
        }

        public void ProceedToNextChallenge()
        {
            var world = worlds[currentWorldIndex];
            currentChallengeIndex++;

            if (currentChallengeIndex < world.Challenges.Count)
            {
                var challenge = world.Challenges[currentChallengeIndex];
                Console.WriteLine($"Challenge: {challenge.Description}");
                bool success = challenge.StartChallenge(protagonist);
                if (success)
                {
                    Console.WriteLine("Challenge overcome. Proceeding to the next challenge...");
                    ProceedToNextChallenge(); // Automatically proceed to the next challenge
                }
                else
                {
                    Console.WriteLine("Challenge failed. Try again or explore other options.");
                }
            }
            else
            {
                Console.WriteLine("All challenges in this world have been completed.");
                HandleWorldCompletion(); // Move to the next world or end the adventure
            }
        }

        public void HandleWorldCompletion()
        {
            if (currentWorldIndex + 1 < worlds.Count)
            {
                currentWorldIndex++;
                currentChallengeIndex = -1;  // Reset challenge index for the new world
                var nextWorld = worlds[currentWorldIndex];
                Console.WriteLine($"Moving on to the next world: {nextWorld.Name}");

                Console.WriteLine("Do you wish to enter the next world now? (Y/N)");
                var response = Console.ReadLine();
                if (response?.ToUpper() == "Y")
                {
                    ExploreWorld(currentWorldIndex); // Continue to the next world
                }
                else
                {
                    Console.WriteLine("Take your time. Explore or interact as you wish.");
                    // Provide options for what the player can do
                }
            }
            else
            {
                Console.WriteLine("Congratulations! You have explored all the worlds and faced all the challenges.");
                // End game or return to the main menu
            }
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
        if (protagonist.QuestLog.All(q => q.IsCompleted) && protagonist.QuestLog.Count !=0)
        {
            Console.WriteLine("Congratulations! You have mastered all the challenges and restored peace to the Academy.");
            return true;
        }
        return false;
    }

    // Additional methods for handling world entry, NPC interactions, and item discoveries could be added here
    public void SaveGameState(string filePath)
    {
        GameState gameState = new GameState
        {
            Protagonist = this.protagonist,
            WorldsState = this.worlds.Select(w => new WorldState(w.Name, w.IsCompleted())).ToList()
            // Populate the GameState with all other needed information
        };

        try
        {
            string jsonString = JsonSerializer.Serialize(gameState, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Game saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the game: {ex.Message}");
        }
    }

[Serializable]
public class GameState
{
    public Protagonist Protagonist { get; set; }
    public List<WorldState> WorldsState { get; set; } = new List<WorldState>();

}

[Serializable]
public class WorldState
{
    public string WorldName { get; set; }
    public bool IsCompleted { get; set; }

    public WorldState(string name, bool completed)
    {
        WorldName = name;
        IsCompleted = completed;
    }
}
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
    private bool readyForNPCInteraction = false;

        public void SetReadyForNPCInteraction(bool ready)
        {
            readyForNPCInteraction = ready;
        }

        public bool IsReadyForNPCInteraction()
        {
            return readyForNPCInteraction;
        }

        public void HandleNPCInteractions()
        {
            // Logic to handle NPC interactions
            // Reset the flag
            SetReadyForNPCInteraction(false);
        }
}
}
