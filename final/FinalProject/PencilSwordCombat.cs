public class PencilSwordCombat : Challenge
{
    private int enemyHealth;
    private int enemyStrength;

    public PencilSwordCombat(string description, int enemyHealth, int enemyStrength) : base(description)
    {
        this.enemyHealth = enemyHealth;
        this.enemyStrength = enemyStrength;
    }

    public override bool StartChallenge(Protagonist protagonist)
    {
        Console.WriteLine(Description);
        bool combatContinues = true;
        bool victory = false; // To track the outcome of the combat

        while (combatContinues && protagonist.IsAlive())
        {
            int damageDealt = CalculateDamage(protagonist.PencilSwordStrength, enemyStrength);
            enemyHealth -= damageDealt;
            Console.WriteLine($"You deal {damageDealt} damage to the enemy.");

            if (enemyHealth <= 0)
            {
                Console.WriteLine("Enemy defeated!");
                victory = true; // The protagonist won the combat
                break;
            }

            int damageReceived = CalculateDamage(enemyStrength, protagonist.PencilSwordStrength);
            protagonist.Health -= damageReceived;
            Console.WriteLine($"The enemy strikes back, dealing {damageReceived} damage. Your health is now {protagonist.Health}.");

            if (!protagonist.IsAlive())
            {
                Console.WriteLine("You have been defeated.");
                break; // No need to set victory to false, as it's already initialized to false
            }

            Console.WriteLine("Press any key to continue to the next turn...");
            Console.ReadKey();
        }

        IsCompleted = victory; // Mark this challenge as completed based on the victory flag
        return victory; // Return the outcome of the combat
    }

    private int CalculateDamage(int playerStrength, int enemyStrength)
    {
        int baseDamage = playerStrength - (enemyStrength / 2);
        return Math.Max(baseDamage, 0); // Ensure damage is not negative
    }
}
