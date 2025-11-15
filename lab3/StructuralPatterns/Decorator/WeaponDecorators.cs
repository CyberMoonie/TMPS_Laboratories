namespace StructuralPatterns.Decorator;

// Base decorator
public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon _weapon;

    public WeaponDecorator(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public virtual string GetDescription()
    {
        return _weapon.GetDescription();
    }

    public virtual int GetDamage()
    {
        return _weapon.GetDamage();
    }
}

// Concrete decorator - adds fire damage
public class FireEnchantment : WeaponDecorator
{
    public FireEnchantment(IWeapon weapon) : base(weapon) { }

    public override string GetDescription()
    {
        return _weapon.GetDescription() + " + Fire Enchantment";
    }

    public override int GetDamage()
    {
        return _weapon.GetDamage() + 15; // +15 fire damage
    }
}

// Concrete decorator - adds poison effect
public class PoisonCoating : WeaponDecorator
{
    public PoisonCoating(IWeapon weapon) : base(weapon) { }

    public override string GetDescription()
    {
        return _weapon.GetDescription() + " + Poison Coating";
    }

    public override int GetDamage()
    {
        return _weapon.GetDamage() + 8; // +8 poison damage
    }
}

// Concrete decorator - adds sharpening
public class Sharpened : WeaponDecorator
{
    public Sharpened(IWeapon weapon) : base(weapon) { }

    public override string GetDescription()
    {
        return _weapon.GetDescription() + " + Sharpened Edge";
    }

    public override int GetDamage()
    {
        return _weapon.GetDamage() + 5; // +5 damage
    }
}
