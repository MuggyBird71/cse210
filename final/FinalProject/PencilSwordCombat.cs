using System;
public class PencilSwordCombat : Challenge
{
    private int enemyHealth;
    private int enemyStrength;

    public PencilSwordCombat(string description, int enemyHealth, int enemyStrength) : base(description)
    {
        this.enemyHealth = enemyHealth;
        this.enemyStrength = enemyStrength;
    }

    public override void StartChallenge(Protagonist protagonist)
    {
        Console.WriteLine(Description);
        Console.WriteLine("Choose your action: (A) Attack, (D) Defend");
        string choice = Console.ReadLine();

        switch (choice.ToUpper())
        {
            case "A":
                protagonist.PencilSwordHit();
                // Calculate damage to the enemy
                int damageToEnemy = CalculateDamage(protagonist.PencilSwordStrength, enemyStrength);
                enemyHealth -= damageToEnemy;
                Console.WriteLine($"You dealt {damageToEnemy} damage to the enemy.");
                break;
            case "D":
                // Implement defend logic
                Console.WriteLine("You raise your shield to defend against the enemy's attack.");
                break;
            default:
                Console.WriteLine("Invalid choice. You hesitate and lose your turn.");
                break;
        }

        // Check if the enemy is defeated
        if (enemyHealth <= 0)
        {
            Console.WriteLine("You have defeated the enemy!");
        }
        else
        {
            // Implement enemy's turn or additional player actions
        }
    }

    private int CalculateDamage(int playerStrength, int enemyStrength)
    {
        // Simple damage calculation for demonstration
        return playerStrength - enemyStrength;
    }
}
