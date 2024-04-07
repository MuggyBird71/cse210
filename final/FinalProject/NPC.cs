using System;
using System.Collections.Generic;

public class NPC
{
    public string Name { get; set; }
    public string Dialogue { get; set; }

    public NPC(string name, string dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");
    }

    public static NPC FindNPCByName(List<NPC> npcs, string name)
    {
        foreach (NPC npc in npcs)
        {
            if (npc.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return npc;
            }
        }
        return null;
    }
}
