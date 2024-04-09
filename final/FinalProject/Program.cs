using System;
using System.Text.Json;
using System.IO;
using MyGame.Engine;
using MyGame.Characters;
using System.Diagnostics;

class Program{
static void Main(string[] args)
{
    Protagonist player = new Protagonist("Hero", 100, 20);
    GameEngine gameEngine = new GameEngine(player);

    gameEngine.SetupWorlds();
    Console.WriteLine("Welcome to Nerd's Revenge: The Homework Crusade!");

    bool gameRunning = true; // Flag to control the game loop

    while (gameRunning && player.IsAlive() && !gameEngine.IsGameOver())
    {
        Console.WriteLine("\nChoose an action:");
        Console.WriteLine("1: Explore next world");
        Console.WriteLine("2: View inventory");
        Console.WriteLine("3: Rest (Restore Health)");
        Console.WriteLine("4: View quest log");
        Console.WriteLine("5: Save Game");
        Console.WriteLine("6: Load Game");
        Console.WriteLine("7: Quit");
        string choice = Console.ReadLine();
        string saveFilePath;
        switch (choice)
        {
            case "1":
                gameEngine.StartAdventure();
                break;
            case "2":
                player.DisplayInventory();
                break;
            case "3":
                player.Rest();
                break;
            case "4":
                player.DisplayQuestLog();
                break;
            case "5":
                saveFilePath = "savegame.json";
                gameEngine.SaveGameState(saveFilePath);
                break;
            case "6": // Fix this. 
                saveFilePath = "savegame.json";
                Protagonist loadedPlayer = gameEngine.LoadGameState(saveFilePath);
                if (loadedPlayer != null)
                {
                    player = loadedPlayer;
                    Console.WriteLine("Game state updated successfully.");
                }
                break;
            case "7": // Quit option
                gameRunning = false; // This will exit the game loop
                Console.WriteLine("Exiting the game...");
                break;
            default:
                Console.WriteLine("Invalid choice, please select again.");
                break;
        }
    }
    Console.WriteLine("Game Over!");
}
}
