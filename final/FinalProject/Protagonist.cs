using System;
using System.Collections.Generic;
using System.Linq;

class Protagonist
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int AttackDamage { get; private set; }
    public int Defense { get; private set; }
    public Location CurrentLocation { get; private set; }

    public List<Item> Inventory { get; private set; }

    public Protagonist(string name, int health, int attackDamage, int defense, Location startingLocation)
    {
        Name = name;
        Health = MaxHealth = health;
        AttackDamage = attackDamage;
        Defense = defense;
        CurrentLocation = startingLocation;
        Inventory = new List<Item>();
    }

    public void MoveTo(Location newLocation)
    {
        CurrentLocation = newLocation;
        Console.WriteLine($"Moved to {newLocation.Name}");
    }

    public void TakeDamage(int damage)
    {
        int netDamage = Math.Max(damage - Defense, 0);
        Health -= netDamage;
        Console.WriteLine($"{Name} took {netDamage} damage.");

        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
            // Implement game over logic or respawn mechanism
        }
    }
    public void IncreaseAttackDamage(int amount)
    {
        AttackDamage += amount;
        Console.WriteLine($"{Name}'s attack damage has been increased by {amount}.");
    }

    // Method to increase defense
    public void IncreaseDefense(int amount)
    {
        Defense += amount;
        Console.WriteLine($"{Name}'s defense has been increased by {amount}.");
    }
    public void Heal(int amount)
    {
        Health = Math.Min(Health + amount, MaxHealth);
        Console.WriteLine($"{Name} healed for {amount} points.");
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void UseItem(string itemName)
    {
        var item = Inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        if (item != null)
        {
            // Assuming the Item class has a method to execute its effect
            // This is a placeholder to illustrate the concept
            item.Use(this);
            Inventory.Remove(item);
            Console.WriteLine($"{itemName} used.");
        }
        else
        {
            Console.WriteLine($"{itemName} not found in inventory.");
        }
    }

    // Example method to interact with NPCs in the current location
    public void InteractWithNPC(string npcName)
    {
        var npc = CurrentLocation.GetNPCs().FirstOrDefault(n => n.Name.Equals(npcName, StringComparison.OrdinalIgnoreCase));
        if (npc != null)
        {
            npc.Interact();
        }
        else
        {
            Console.WriteLine($"{npcName} not found in {CurrentLocation.Name}.");
        }
    }

    // Additional functionalities like attacking, engaging in dialogues, solving puzzles, etc., can be added here
}
