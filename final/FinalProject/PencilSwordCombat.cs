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
        // Example simplified logic for combat
        int damageDealt = CalculateDamage(protagonist.PencilSwordStrength, enemyStrength);
        enemyHealth -= damageDealt;
        Console.WriteLine($"You deal {damageDealt} damage to the enemy.");
        
        if (enemyHealth <= 0) {
            Console.WriteLine("Enemy defeated!");
        } else {
            Console.WriteLine($"The enemy has {enemyHealth} health remaining.");
        }
    }

    private int CalculateDamage(int playerStrength, int enemyStrength)
    {
        return playerStrength - enemyStrength;
    }
}
