using System.Collections.Generic;
using System.Linq;

class World
{
    public static Location StartingLocation { get; private set; }
    private List<Location> locations;

    public World()
    {
        locations = new List<Location>();
        InitializeWorld();
    }

    private void InitializeWorld()
    {
        // Expanded thematic locations
        Location mathWorld = new Location("Math World", "Solve puzzles and fight against calculus dragons.", true);
        Location scienceLab = new Location("Science Lab", "Battle through experiments gone wrong.", false);
        Location literatureLibrary = new Location("Literature Library", "Navigate through mazes of classic and modern literature.", false);
        Location historyHall = new Location("History Hall", "Explore ancient civilizations and their challenges.", false);
        Location artGallery = new Location("Art Gallery", "Discover the world's most famous paintings and their secrets.", false); // New location
        Location techPark = new Location("Tech Park", "Dive into the future and explore cutting-edge technology.", false); // New location

        // Adding educational NPCs with unique challenges
        NPC mathNPC = new NPC("Pythagoras", 50, 8, 3, "What is the hypotenuse of a triangle with sides 3 and 4?", "5");
        NPC scienceNPC = new NPC("Curie", 60, 10, 5, "What element did Marie Curie discover?", "Radium");
        NPC literatureNPC = new NPC("Shakespeare", 70, 12, 4, "To be, or not to be, that is the question from which work?", "Hamlet"); // New NPC
        NPC historyNPC = new NPC("Cleopatra", 80, 15, 5, "Which country was Cleopatra the last active ruler of?", "Egypt"); // New NPC
        NPC artNPC = new NPC("Van Gogh", 85, 15, 6, "What is Van Gogh's most famous piece of art?", "Starry Night"); // New NPC
        NPC techNPC = new NPC("Ada Lovelace", 90, 18, 7, "Who is considered the world's first computer programmer?", "Ada Lovelace"); // New NPC

        // Adding NPCs to locations
        mathWorld.AddNPC(mathNPC);
        scienceLab.AddNPC(scienceNPC);
        literatureLibrary.AddNPC(literatureNPC);
        historyHall.AddNPC(historyNPC);
        artGallery.AddNPC(artNPC);
        techPark.AddNPC(techNPC);

        // Setting up connections
        ConnectLocations(mathWorld, scienceLab);
        ConnectLocations(scienceLab, literatureLibrary);
        // Dynamic connections based on unlocking achievements or learning milestones
        // Example: Unlock Tech Park after solving a certain number of science and math challenges

        // Setting the starting location and adding all locations to the world
        StartingLocation = mathWorld;
        locations.AddRange(new[] { mathWorld, scienceLab, literatureLibrary, historyHall, artGallery, techPark });
    }

    private void ConnectLocations(Location location1, Location location2)
    {
        if (!location1.IsUnlocked || !location2.IsUnlocked) return; // Ensure both locations are unlocked before connecting

        location1.AddConnection(location2);
        location2.AddConnection(location1);
    }

    public void UnlockLocation(string locationName)
    {
        var locationToUnlock = locations.FirstOrDefault(loc => loc.Name == locationName && !loc.IsUnlocked);
        if (locationToUnlock != null)
        {
            locationToUnlock.Unlock();
            // After unlocking, attempt to connect this location to others that are also unlocked
            foreach (var location in locations.Where(loc => loc.IsUnlocked && loc != locationToUnlock))
            {
                ConnectLocations(locationToUnlock, location);
            }
            System.Console.WriteLine($"{locationName} has been unlocked and connected to other available locations!");
        }
        else
        {
            System.Console.WriteLine("Location not found or already unlocked.");
        }
    }

    public Location GetLocationByName(string name)
    {
        return locations.FirstOrDefault(loc => loc.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
    }
}
