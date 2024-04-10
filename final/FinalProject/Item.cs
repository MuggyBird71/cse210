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

    // Consider adding methods for using items with effects based on their type.
}
