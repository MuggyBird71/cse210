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
        // Define thematic locations
        Location mathWorld = new Location("Math World", "Solve puzzles and fight against calculus dragons.");
        Location scienceLab = new Location("Science Lab", "Battle through experiments gone wrong.");
        Location literatureLibrary = new Location("Literature Library", "Navigate through mazes of classic and modern literature.");
        Location historyHall = new Location("History Hall", "Explore ancient civilizations and their challenges.");
        Location artGallery = new Location("Art Gallery", "Discover the world's most famous paintings and their secrets.");
        Location techPark = new Location("Tech Park", "Dive into the future and explore cutting-edge technology.");
        
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

        ConnectLocations(mathWorld, scienceLab);
        ConnectLocations(scienceLab, literatureLibrary);
        ConnectLocations(literatureLibrary, historyHall);
        ConnectLocations(historyHall, artGallery);
        ConnectLocations(artGallery, techPark);
        ConnectLocations(techPark, mathWorld); // Example to close the loop, adjust according to your game design

        // Set the starting location and add all locations to the world
        StartingLocation = mathWorld;
        locations.AddRange(new[] { mathWorld, scienceLab, literatureLibrary, historyHall, artGallery, techPark });
    }

    private void ConnectLocations(Location location1, Location location2)
    {
        location1.AddConnection(location2);
        location2.AddConnection(location1);
    }

    // The UnlockLocation method is removed since all locations are accessible from the start

    public Location GetLocationByName(string name)
    {
        return locations.FirstOrDefault(loc => loc.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}