public class CharacterStats
{
    public float baseSpeed;
    public float baseJump;
    public float baseHealth;
    public float baseAttack;
    // Add more base stats as needed
}

public abstract class CharacterClass
{
    public CharacterStats stats = new CharacterStats();

    public abstract void SetBaseStats();
}

public class Warrior : CharacterClass
{
    public override void SetBaseStats()
    {
        stats.baseSpeed = 1.0f;
        stats.baseJump = 1.75f;
        stats.baseHealth = 200.0f;
        stats.baseAttack = 15.0f;
        // Set more base stats as needed
    }
}

public class Mage : CharacterClass
{
    public override void SetBaseStats()
    {
        stats.baseSpeed = 1.0f;
        stats.baseHealth = 100.0f;
        stats.baseAttack = 10.0f;
        // Set more base stats as needed
    }
}

public class Rogue : CharacterClass
{
    public override void SetBaseStats()
    {
        stats.baseSpeed = 1.5f;
        stats.baseHealth = 150.0f;
        stats.baseAttack = 12.0f;
        // Set more base stats as needed
    }
}