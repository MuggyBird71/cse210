using System;

class Program
{
    static void Main(string[] args)
    {
        Protagonist player = new Protagonist("PlayerName", 100, 20);
        GameEngine gameEngine = new GameEngine(player);

        // Instantiate objects from your other classes as needed
        AdventureWorld world = new AdventureWorld();
        Challenge challenge = new Challenge();
        NPC npc = new NPC();
        PencilSwordCombat pencilSwordCombat = new PencilSwordCombat();
        PuzzleChallenge puzzleChallenge = new PuzzleChallenge();

        gameEngine.SetupWorlds();
        gameEngine.StartAdventure();

        bool gameOver = false;
        while (!gameOver)
        {
            // Your game loop logic
        }

        Console.WriteLine("Game Over!");
    }
}
