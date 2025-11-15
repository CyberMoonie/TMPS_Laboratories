namespace StructuralPatterns.Decorator;

// Component interface
public interface IWeapon
{
    string GetDescription();
    int GetDamage();
}

// Concrete component - base weapon
public class BasicSword : IWeapon
{
    public string GetDescription()
    {
        return "Basic Sword";
    }

    public int GetDamage()
    {
        return 10;
    }
}
