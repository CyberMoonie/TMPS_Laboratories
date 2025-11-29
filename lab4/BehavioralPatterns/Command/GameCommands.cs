namespace BehavioralPatterns.Command;

// Command interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver
public class GameCharacter
{
    public int Health { get; private set; } = 100;
    public int X { get; private set; } = 0;
    public int Y { get; private set; } = 0;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        Console.WriteLine($"  Character took {amount} damage. Health: {Health}");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"  Character healed {amount}. Health: {Health}");
    }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
        Console.WriteLine($"  Character moved to ({X}, {Y})");
    }
}

// Concrete Commands
public class AttackCommand : ICommand
{
    private GameCharacter _character;
    private int _damage;

    public AttackCommand(GameCharacter character, int damage)
    {
        _character = character;
        _damage = damage;
    }

    public void Execute()
    {
        Console.WriteLine("[Command] Executing Attack");
        _character.TakeDamage(_damage);
    }

    public void Undo()
    {
        Console.WriteLine("[Command] Undoing Attack");
        _character.Heal(_damage);
    }
}

public class MoveCommand : ICommand
{
    private GameCharacter _character;
    private int _dx, _dy;

    public MoveCommand(GameCharacter character, int dx, int dy)
    {
        _character = character;
        _dx = dx;
        _dy = dy;
    }

    public void Execute()
    {
        Console.WriteLine("[Command] Executing Move");
        _character.Move(_dx, _dy);
    }

    public void Undo()
    {
        Console.WriteLine("[Command] Undoing Move");
        _character.Move(-_dx, -_dy);
    }
}

// Invoker
public class CommandInvoker
{
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var command = _commandHistory.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("[Invoker] No commands to undo");
        }
    }
}
