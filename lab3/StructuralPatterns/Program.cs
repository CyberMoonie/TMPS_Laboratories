using StructuralPatterns.Facade;
using StructuralPatterns.Decorator;
using StructuralPatterns.Adapter;

namespace StructuralPatterns;

class Program
{
    static void Main(string[] args)
    {

        // 1. FACADE PATTERN
        DemonstrateFacade();

        // 2. DECORATOR PATTERN
        DemonstrateDecorator();

        // 3. ADAPTER PATTERN
        DemonstrateAdapter();

    }

    static void DemonstrateFacade()
    {
        Console.WriteLine("==========1. FACADE PATTERN==========");
        
        // Without facade, you'd need to initialize each subsystem manually
        // With facade, one simple call does it all
        GameFacade game = new GameFacade();
        game.StartGame();
        
        Console.WriteLine("Running game frame:");
        game.RunGameFrame();
        Console.WriteLine();
    }

    static void DemonstrateDecorator()
    {
        Console.WriteLine("==========2. DECORATOR PATTERN==========");

        // Start with a basic weapon
        IWeapon weapon = new BasicSword();
        Console.WriteLine($"Weapon: {weapon.GetDescription()}");
        Console.WriteLine($"Damage: {weapon.GetDamage()}\n");

        // Add fire enchantment
        weapon = new FireEnchantment(weapon);
        Console.WriteLine($"Weapon: {weapon.GetDescription()}");
        Console.WriteLine($"Damage: {weapon.GetDamage()}\n");

        // Add poison coating on top
        weapon = new PoisonCoating(weapon);
        Console.WriteLine($"Weapon: {weapon.GetDescription()}");
        Console.WriteLine($"Damage: {weapon.GetDamage()}\n");

        // Add sharpening on top of everything
        weapon = new Sharpened(weapon);
        Console.WriteLine($"Weapon: {weapon.GetDescription()}");
        Console.WriteLine($"Damage: {weapon.GetDamage()}\n");
    }

    static void DemonstrateAdapter()
    {
        Console.WriteLine("==========3. ADAPTER PATTERN==========");

        // We have a legacy file storage system
        LegacyFileStorage legacyStorage = new LegacyFileStorage();

        // But our game expects ICloudStorage interface
        // Adapter makes them compatible!
        ICloudStorage cloudStorage = new FileStorageAdapter(legacyStorage);

        // Now we can use the modern interface
        cloudStorage.SaveToCloud("Player1", 2500);
        string data = cloudStorage.LoadFromCloud("Player1");
        Console.WriteLine($"Retrieved: {data}\n");
    }
}
