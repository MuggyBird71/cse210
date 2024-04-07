static void Main(string[] args)
{
    // Create a protagonist (player character)
   // Create a protagonist (player character)
Protagonist player = new Protagonist("PlayerName", 100, 20); // Initial health: 100, Initial pencil sword strength: 20

    // Create a game engine with the protagonist
    GameEngine gameEngine = new GameEngine(player);

    // Set up the game world
    gameEngine.SetupWorlds();

    // Start the adventure
    gameEngine.StartAdventure();

    // Game loop example
    bool gameOver = false;
    while (!gameOver)
    {
        // Update game state
        // For simplicity, let's just print a message here
        Console.WriteLine("Updating game state...");

        // Handle player input
        // For simplicity, let's just read a line of input here
        string input = Console.ReadLine();
        Console.WriteLine($"Player input: {input}");

        // Resolve game events
        // For simplicity, let's just print a message here
        Console.WriteLine("Resolving game events...");

        // Check for game over conditions
        // For simplicity, let's set gameOver to true after a certain number of iterations
        // You can replace this with your own game over conditions
        // For example, if the player's health drops to zero
        if (player.Health <= 0)
        {
            gameOver = true;
        }

        // You can also check other conditions here, such as reaching the end of the game
    }

    // Game over logic
    Console.WriteLine("Game Over!");
}
