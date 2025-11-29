namespace BehavioralPatterns.Strategy;

// Strategy interface
public interface IAttackStrategy
{
    void Attack(string target);
}

// Concrete strategies
public class MeleeAttack : IAttackStrategy
{
    public void Attack(string target)
    {
        Console.WriteLine($"  [Melee] Slashing {target} with sword! Damage: 50");
    }
}

public class RangedAttack : IAttackStrategy
{
    public void Attack(string target)
    {
        Console.WriteLine($"  [Ranged] Shooting {target} with bow! Damage: 30");
    }
}

public class MagicAttack : IAttackStrategy
{
    public void Attack(string target)
    {
        Console.WriteLine($"  [Magic] Casting fireball at {target}! Damage: 80");
    }
}

// Context class
public class Player
{
    private IAttackStrategy _attackStrategy;
    public string Name { get; set; }

    public Player(string name, IAttackStrategy attackStrategy)
    {
        Name = name;
        _attackStrategy = attackStrategy;
    }

    public void SetAttackStrategy(IAttackStrategy strategy)
    {
        _attackStrategy = strategy;
        Console.WriteLine($"[{Name}] Changed attack strategy to {strategy.GetType().Name}");
    }

    public void PerformAttack(string target)
    {
        _attackStrategy.Attack(target);
    }
}
