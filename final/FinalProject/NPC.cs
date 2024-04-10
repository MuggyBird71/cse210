using System;

class NPC : Character
{
    public List<string> Dialogues { get; private set; }
    public bool IsTeacher { get; private set; }
    public string Question { get; private set; }
    public string Answer { get; private set; }

    // Constructor for regular NPCs
    public NPC(string name, int health, int attackDamage, int defense, List<string> dialogues) 
        : base(name, health, attackDamage, defense)
    {
        Dialogues = dialogues ?? new List<string>();
        IsTeacher = false;
    }

    // Constructor for Teacher NPCs with educational challenges
    public NPC(string name, int health, int attackDamage, int defense, string question, string answer) 
        : base(name, health, attackDamage, defense)
    {
        Question = question;
        Answer = answer;
        IsTeacher = true;
    }

    public void Interact()
    {
        if (IsTeacher)
        {
            Console.WriteLine($"{Name} challenges you with a question: {Question}");
            Console.Write("Your answer: ");
            string userAnswer = Console.ReadLine();
            if (userAnswer.Trim().Equals(Answer, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct! You have bested this challenge.");
            }
            else
            {
                Console.WriteLine("Incorrect. Better luck next time.");
            }
        }
        else
        {
            foreach (var dialogue in Dialogues)
            {
                Console.WriteLine($"{Name} says: \"{dialogue}\"");
            }
        }
    }
}
