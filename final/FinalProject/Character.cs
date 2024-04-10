using System;

class Character
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int AttackDamage { get; private set; }
    public int Defense { get; private set; }

    public Character(string name, int health, int attackDamage, int defense)
    {
        Name = name;
        Health = health;
        AttackDamage = attackDamage;
        Defense = defense;
    }

    public void TakeDamage(int damage)
    {
        // Reduce character's health by the damage amount
        Health -= damage;

        // Ensure health does not go below 0
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void Attack(Character target)
    {
        // Calculate damage dealt to the target based on attacker's attack damage and defender's defense
        int damageDealt = Math.Max(AttackDamage - target.Defense, 0);

        // Apply damage to the target
        target.TakeDamage(damageDealt);

        // Display attack result
        Console.WriteLine($"{Name} attacks {target.Name} for {damageDealt} damage!");
    }

    // Additional methods and properties related to characters can be added here
}