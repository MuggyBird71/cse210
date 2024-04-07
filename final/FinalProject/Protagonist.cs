using System;

public class Protagonist
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int PencilSwordStrength { get; set; }

    // Constructor to initialize properties
    public Protagonist(string name, int health, int pencilSwordStrength)
    {
        Name = name;
        Health = health;
        PencilSwordStrength = pencilSwordStrength;
    }

    // Method to perform a pencil sword hit
    public void PencilSwordHit()
    {
        Console.WriteLine($"{Name} strikes with the Pencil Sword with strength {PencilSwordStrength}.");
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Current health: {Health}");
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
            // Additional game over logic here...
        }
    }

    // Method to heal
    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} heals for {amount} health. Current health: {Health}");
    }
}
