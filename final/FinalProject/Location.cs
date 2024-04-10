using System;
using System.Collections.Generic;
using System.Linq;

class Location
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private List<Location> connectedLocations;
    private List<NPC> npcs;
    public bool IsUnlocked { get; private set; } // New property to track if the location is unlocked

    // Constructor
    public Location(string name, string description, bool isUnlocked = false)
    {
        Name = name;
        Description = description;
        connectedLocations = new List<Location>();
        npcs = new List<NPC>();
        IsUnlocked = isUnlocked; // Initially, some locations might be locked
    }

    // Method to unlock the location
    public void Unlock()
    {
        IsUnlocked = true;
        OnLocationUnlocked(); // Optional: Notify the game or player that a new location has been unlocked
    }

    // Method to add a connected location
    public void AddConnection(Location location)
    {
        if (!connectedLocations.Contains(location))
        {
            connectedLocations.Add(location);
        }
    }

    // Method to get the list of unlocked connected locations
    public List<Location> GetConnectedLocations()
    {
        return connectedLocations.Where(loc => loc.IsUnlocked).ToList();
    }

    // Method to add an NPC to the location
    public void AddNPC(NPC npc)
    {
        if (!npcs.Contains(npc))
        {
            npcs.Add(npc);
        }
    }

    // Method to get the list of NPCs in the location
    public List<NPC> GetNPCs()
    {
        return npcs;
    }

    // Method to update the description of the location
    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
    }

    // Optional: A method to handle location-specific events or challenges
    public void TriggerEvent(string eventName)
    {
        // Logic to trigger an event or challenge based on the eventName
        Console.WriteLine($"Event triggered: {eventName} in {Name}");
        // This can include unlocking new areas, revealing hidden NPCs, or changing the location's description
    }

    // Optional: Callback method when the location is unlocked
    protected virtual void OnLocationUnlocked()
    {
        Console.WriteLine($"{Name} has been unlocked!");
        // This method can be overridden in derived classes for location-specific unlock behaviors
    }
}
