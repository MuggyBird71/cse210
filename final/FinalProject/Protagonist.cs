using System.Collections.Generic;

class Protagonist
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int AttackDamage { get; private set; }
    public int Defense { get; private set; }
    public Location CurrentLocation { get; private set; }

    // Inventory property to hold the player's items
    public List<Item> Inventory { get; private set; }

    public Protagonist(string name, int health, int attackDamage, int defense, Location startingLocation)
    {
        Name = name;
        Health = health;
        AttackDamage = attackDamage;
        Defense = defense;
        CurrentLocation = startingLocation;

        // Initialize the inventory
        Inventory = new List<Item>();
    }
    public void MoveTo(Location newLocation)
    {
        CurrentLocation = newLocation;
    }

    // Other methods and properties of the Protagonist class...
}