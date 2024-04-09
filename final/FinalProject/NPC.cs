using System;

public class NPC
{
    public string Name { get; private set; }
    public string Dialogue { get; private set; }

    public NPC(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");
    }

    public void Interact(Protagonist protagonist)
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");

        if (Name == "Math Wizard")
        {
            Console.WriteLine("What is 4 - 2? (Enter the title)");
            string playerAnswer = Console.ReadLine();
            if (playerAnswer.Equals("2", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct! The Math Wizard lights his pipe shaped like a factorial.");
                // protagonist.AddItemToInventory(new InventoryItem("Clue", "A mysterious note from Shakespeare's Ghost."));
            }
            else
            {
                Console.WriteLine("Incorrect. You are the biggest idiot ever.");
            }
        }

        if (Name == "Shakespeare's Ghost")
        {
            Console.WriteLine("Can you name the play? 'To be, or not to be, that is the question.' (Enter the title)");
            string playerAnswer = Console.ReadLine();
            if (playerAnswer.Equals("Hamlet", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct! The ghost smiles and fades away, leaving behind a clue.");
                // protagonist.AddItemToInventory(new InventoryItem("Clue", "A mysterious note from Shakespeare's Ghost."));
            }
            else
            {
                Console.WriteLine("Incorrect. The ghost sighs and disappears.");
            }
        }

        if (Name == "The Time Traveler")
        {
            Console.WriteLine("The United States bought Alaska from which country? (Enter the title)");
            string playerAnswer = Console.ReadLine();
            if (playerAnswer.Equals("Russia", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct! The Time Traveler melts away and lets you by.");
                // protagonist.AddItemToInventory(new InventoryItem("Clue", "A mysterious note from Shakespeare's Ghost."));
            }
            else
            {
                Console.WriteLine("Incorrect. The Time Travler explodes and leaves only history textbooks.");
            }
        }
        if (Name == "Space Charlie Chaplin")
        {
            Console.WriteLine("What is the best science fiction movie? (Enter the title)");
            string playerAnswer = Console.ReadLine();
            Console.WriteLine("Interesting choice! The mysterious figure nods in approval and hands you a clue.");
        }
    }
}
