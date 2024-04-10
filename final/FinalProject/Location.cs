using System;
using System.Collections.Generic;
using System.Linq;

class Location
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private List<Location> connectedLocations;
    private List<NPC> npcs;

    // Constructor
    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        connectedLocations = new List<Location>();
        npcs = new List<NPC>();
    }

    // Method to add a connected location
    public void AddConnection(Location location)
    {
        if (!connectedLocations.Contains(location))
        {
            connectedLocations.Add(location);
        }
    }

    // Method to get the list of connected locations
    public List<Location> GetConnectedLocations()
    {
        return new List<Location>(connectedLocations); // Directly return all connected locations without checking for unlock status
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
        return new List<NPC>(npcs);
    }

    // Method to update the description of the location
    public void UpdateDescription(string newDescription)
    {
        Description = newDescription;
    }

    // Optional: A method to handle location-specific events or challenges
    public void TriggerEvent(string eventName)
    {
        Console.WriteLine($"Event triggered: {eventName} in {Name}");
    }

    // Removing the Unlock method and IsUnlocked property since all locations will be accessible from the start
}
