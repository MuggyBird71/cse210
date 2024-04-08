using System;
using System.Collections.Generic;

public class DialogueSystem
{
    public void StartDialogue(NPC npc, Protagonist protagonist)
    {
        Console.WriteLine($"{npc.Name} says: \"{npc.Dialogue}\"");
        
        // Example dialogue with choices
        Console.WriteLine("1: Agree with the NPC");
        Console.WriteLine("2: Disagree with the NPC");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                protagonist.AdjustRelationshipScore(npc.Name, 10); // Improve relationship
                break;
            case "2":
                protagonist.AdjustRelationshipScore(npc.Name, -10); // Damage relationship
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
