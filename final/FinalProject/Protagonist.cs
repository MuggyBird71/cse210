using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text.Json;
using System.IO;

namespace MyGame.Characters
{
public class Protagonist
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int PencilSwordStrength { get; set; }
    public List<InventoryItem> Inventory { get; set; } = new List<InventoryItem>();
    public List<Quest> QuestLog { get; set; } = new List<Quest>();
    public List<Quest> ActiveQuests { get; set; } = new List<Quest>();
    public Dictionary<string, int> RelationshipScores { get; set; } = new Dictionary<string, int>();
    
    

    public Protagonist(string name, int health, int pencilSwordStrength)
    {
        Name = name;
        Health = health;
        MaxHealth = 100;
        PencilSwordStrength = pencilSwordStrength;   
    }

    public void PencilSwordHit()
    {
        Console.WriteLine($"{Name} strikes with the Pencil Sword!");
    }

        public void Defend(int enemyAttackStrength)
    {
        int damage = enemyAttackStrength / 2;
        Health = Math.Max(0, Health - damage);
        Console.WriteLine($"{Name} defended and reduced damage to {damage}. Current health: {Health}");
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Your Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"{item.Name}: {item.Description}");
        }
    }

    public void AddItemToInventory(InventoryItem item)
    {
        Inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void AcceptQuest(Quest quest)
    {
        QuestLog.Add(quest);
        Console.WriteLine($"Quest accepted: {quest.Title}");
    }

    public void CompleteQuest(string questTitle)
{
    var quest = QuestLog.FirstOrDefault(q => q.Title == questTitle);
    if (quest != null)
    {
        quest.IsCompleted = true;
        Console.WriteLine($"Quest completed: {quest.Title}");
        // If you decide to remove the quest upon completion
        QuestLog.Remove(quest);
    }
}


    public void AdjustRelationshipScore(string npcName, int scoreAdjustment)
    {
        if (RelationshipScores.ContainsKey(npcName))
        {
            RelationshipScores[npcName] += scoreAdjustment;
        }
        else
        {
            RelationshipScores.Add(npcName, scoreAdjustment);
        }
    }
    public void Rest()
    {
        Health = MaxHealth;
        Console.WriteLine($"{Name} has rested and restored health to full ({MaxHealth}).");
    }
    
    public void DisplayQuestLog()
    {
        Console.WriteLine("Quest Log:");
        foreach (var quest in QuestLog)
        {
            string status = quest.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($"{quest.Title} - {status}");
        }
    }
}

public class InventoryItem
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Quest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false; // Default value is false

    public Quest(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
}
