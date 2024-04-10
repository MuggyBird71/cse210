class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Quantity { get; set; }
    public ItemType Type { get; private set; }

    public enum ItemType
    {
        HealthPotion,
        AttackBoost,
        DefenseBoost,
        EducationalMaterial // Could unlock additional content, hints, or provide bonuses for educational challenges
    }

    public Item(string name, string description, int quantity, ItemType type)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
        Type = type;
    }

    public void Use(Protagonist protagonist)
    {
        switch (Type)
        {
            case ItemType.HealthPotion:
                protagonist.Heal(20); // Assuming a fixed healing amount; this could be a property of the item
                Console.WriteLine($"{protagonist.Name} has been healed.");
                break;
            case ItemType.AttackBoost:
                protagonist.IncreaseAttackDamage(5);
                break;
            case ItemType.DefenseBoost:
                protagonist.IncreaseDefense(5);
                break;
        // The rest
            case ItemType.EducationalMaterial:
                // Trigger some educational content or bonus
                Console.WriteLine($"{protagonist.Name} has learned something new!");
                // This could potentially unlock new abilities or provide hints for puzzles
                break;
            default:
                Console.WriteLine("Unknown item type.");
                break;
        }

        Quantity--; // Reduce the quantity of the item after use
        if (Quantity <= 0)
        {
            // Optionally remove the item from the inventory if the quantity drops to 0
            protagonist.Inventory.Remove(this);
        }
    }
}
