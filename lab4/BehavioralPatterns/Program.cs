using BehavioralPatterns.Strategy;
using BehavioralPatterns.Observer;
using BehavioralPatterns.Command;

namespace BehavioralPatterns;

class Program
{
    static void Main(string[] args)
    {

        // 1. STRATEGY PATTERN
        DemonstrateStrategy();

        // 2. OBSERVER PATTERN
        DemonstrateObserver();

        // 3. COMMAND PATTERN
        DemonstrateCommand();

    }

    static void DemonstrateStrategy()
    {
        Console.WriteLine("==========1. STRATEGY PATTERN==========\n");

        var player = new Player("Hero", new MeleeAttack());
        player.PerformAttack("Goblin");

        player.SetAttackStrategy(new RangedAttack());
        player.PerformAttack("Dragon");

        player.SetAttackStrategy(new MagicAttack());
        player.PerformAttack("Boss");

        Console.WriteLine();
    }

    static void DemonstrateObserver()
    {
        Console.WriteLine("==========2. OBSERVER PATTERN==========");

        var playerActions = new PlayerActions("Hero");
        
        var achievements = new AchievementSystem();
        var statistics = new StatisticsTracker();
        var notifications = new NotificationService();

        playerActions.Attach(achievements);
        playerActions.Attach(statistics);
        playerActions.Attach(notifications);

        playerActions.KillEnemy();
        playerActions.CollectItem();

        Console.WriteLine();
    }

    static void DemonstrateCommand()
    {
        Console.WriteLine("==========3. COMMAND PATTERN==========\n");

        var character = new GameCharacter();
        var invoker = new CommandInvoker();

        Console.WriteLine($"Initial state - Health: {character.Health}, Position: ({character.X}, {character.Y})\n");

        var move1 = new MoveCommand(character, 5, 3);
        invoker.ExecuteCommand(move1);

        var attack1 = new AttackCommand(character, 20);
        invoker.ExecuteCommand(attack1);

        var move2 = new MoveCommand(character, -2, 4);
        invoker.ExecuteCommand(move2);

        Console.WriteLine("\n--- Undoing commands ---\n");
        invoker.UndoLastCommand();
        invoker.UndoLastCommand();
        invoker.UndoLastCommand();

        Console.WriteLine();
    }
}
