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

        if (Name == "The Wise Old Librarian")
        {
            Console.WriteLine("Would you like to embark on a quest to retrieve the Ancient Book? (Y/N)");
            string choice = Console.ReadLine();
            while (choice.ToUpper() != "Y" && choice.ToUpper() != "N")
            {
                Console.WriteLine("Please answer Y or N:");
                choice = Console.ReadLine();
            }

            if (choice.ToUpper() == "Y")
            {
                Console.WriteLine("You have accepted the quest!");
                protagonist.AcceptQuest(new Quest("Retrieve the Ancient Book", "QuestDescription"));
            }
        }
    }
}
