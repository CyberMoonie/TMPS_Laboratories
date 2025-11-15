# Structural Design Patterns

## What are Structural Design Patterns?

**Structural Design Patterns** deal with object composition, creating relationships between objects to form larger structures. They help ensure that if one part of a system changes, the entire system doesn't need to change. These patterns explain how to assemble objects and classes into larger structures while keeping them flexible and efficient.

### Common Structural Patterns:

- **Adapter** - Converts one interface to another that clients expect
- **Bridge** - Separates abstraction from implementation
- **Composite** - Composes objects into tree structures
- **Decorator** - Adds responsibilities to objects dynamically
- **Facade** - Provides simplified interface to complex subsystems
- **Flyweight** - Shares objects to support large numbers efficiently
- **Proxy** - Provides placeholder for another object to control access

### Patterns Used in This Laboratory: **Facade, Decorator, Adapter**

---

## 1. Facade Pattern

### Theory:

> Provides a simplified, unified interface to a complex subsystem. Hides complexity behind a single interface.

**Use when:** You have multiple complex subsystems that need to work together, and you want to provide a simple interface to clients.

### Implementation:

#### GameSubsystems.cs

```csharp
namespace StructuralPatterns.Facade;

// Complex subsystem components
public class GraphicsEngine
{
    public void Initialize()
    {
        Console.WriteLine("  [Graphics] Initializing graphics engine...");
    }

    public void LoadTextures()
    {
        Console.WriteLine("  [Graphics] Loading textures...");
    }

    public void Render()
    {
        Console.WriteLine("  [Graphics] Rendering frame...");
    }
}

public class AudioSystem
{
    public void Initialize()
    {
        Console.WriteLine("  [Audio] Initializing audio system...");
    }

    public void LoadSounds()
    {
        Console.WriteLine("  [Audio] Loading sound effects...");
    }

    public void PlayBackgroundMusic()
    {
        Console.WriteLine("  [Audio] Playing background music...");
    }
}

public class InputManager
{
    public void Initialize()
    {
        Console.WriteLine("  [Input] Initializing input manager...");
    }

    public void DetectControllers()
    {
        Console.WriteLine("  [Input] Detecting controllers...");
    }
}

public class NetworkManager
{
    public void Initialize()
    {
        Console.WriteLine("  [Network] Initializing network...");
    }

    public void ConnectToServer()
    {
        Console.WriteLine("  [Network] Connecting to game server...");
    }
}
```

#### GameFacade.cs

```csharp
namespace StructuralPatterns.Facade;

// Facade that simplifies the complex subsystems
public class GameFacade
{
    private readonly GraphicsEngine _graphics;
    private readonly AudioSystem _audio;
    private readonly InputManager _input;
    private readonly NetworkManager _network;

    public GameFacade()
    {
        _graphics = new GraphicsEngine();
        _audio = new AudioSystem();
        _input = new InputManager();
        _network = new NetworkManager();
    }

    // Simple method that hides complex initialization
    public void StartGame()
    {
        Console.WriteLine("\n[Facade] Starting game - simplified interface");
        _graphics.Initialize();
        _graphics.LoadTextures();
        _audio.Initialize();
        _audio.LoadSounds();
        _input.Initialize();
        _input.DetectControllers();
        _network.Initialize();
        _network.ConnectToServer();
        Console.WriteLine("[Facade] Game started successfully!\n");
    }

    // Simple method for game loop
    public void RunGameFrame()
    {
        _graphics.Render();
        _audio.PlayBackgroundMusic();
    }
}
```

**Why Facade:**

- Simplifies complex subsystem interactions
- Client calls one method instead of managing multiple subsystems
- Reduces dependencies between client and subsystems
- Provides a clean, easy-to-use interface

**Usage:**

```csharp
GameFacade game = new GameFacade();
game.StartGame(); // Initializes all subsystems with one call
game.RunGameFrame();
```

---

## 2. Decorator Pattern

### Theory:

> Dynamically adds new functionality to objects without altering their structure. Wraps objects in decorator classes that add behavior.

**Use when:** You need to add responsibilities to objects dynamically and transparently, without affecting other objects.

### Implementation:

#### IWeapon.cs

```csharp
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
```

#### WeaponDecorators.cs

```csharp
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
```

**Why Decorator:**

- Adds functionality dynamically at runtime
- Avoids class explosion (no need for FirePoisonSharpenedSword class)
- Flexible - stack decorators in any order
- Follows Open/Closed Principle (open for extension, closed for modification)

**Usage:**

```csharp
IWeapon weapon = new BasicSword();
weapon = new FireEnchantment(weapon);
weapon = new PoisonCoating(weapon);
weapon = new Sharpened(weapon);
// Damage: 10 + 15 + 8 + 5 = 38
```

---

## 3. Adapter Pattern

### Theory:

> Converts the interface of a class into another interface clients expect. Allows incompatible interfaces to work together.

**Use when:** You need to use an existing class with an incompatible interface, or want to create reusable classes that cooperate with unrelated classes.

### Implementation:

#### StorageInterfaces.cs

```csharp
namespace StructuralPatterns.Adapter;

// Modern interface that our game expects
public interface ICloudStorage
{
    void SaveToCloud(string playerName, int score);
    string LoadFromCloud(string playerName);
}

// Legacy system with incompatible interface
public class LegacyFileStorage
{
    public void WriteToFile(string filename, string data)
    {
        Console.WriteLine($"  [Legacy] Writing to file: {filename}");
        Console.WriteLine($"  [Legacy] Data: {data}");
    }

    public string ReadFromFile(string filename)
    {
        Console.WriteLine($"  [Legacy] Reading from file: {filename}");
        return "PlayerData: Score=1000"; // Simulated file content
    }
}
```

#### FileStorageAdapter.cs

```csharp
namespace StructuralPatterns.Adapter;

// Adapter that makes legacy system work with modern interface
public class FileStorageAdapter : ICloudStorage
{
    private readonly LegacyFileStorage _legacyStorage;

    public FileStorageAdapter(LegacyFileStorage legacyStorage)
    {
        _legacyStorage = legacyStorage;
    }

    public void SaveToCloud(string playerName, int score)
    {
        Console.WriteLine("[Adapter] Converting cloud save request to file operation...");

        // Adapt the interface: convert parameters to legacy format
        string filename = $"{playerName}.dat";
        string data = $"PlayerData: Score={score}";

        _legacyStorage.WriteToFile(filename, data);
        Console.WriteLine("[Adapter] Save completed!\n");
    }

    public string LoadFromCloud(string playerName)
    {
        Console.WriteLine("[Adapter] Converting cloud load request to file operation...");

        // Adapt the interface: convert parameters to legacy format
        string filename = $"{playerName}.dat";
        string fileContent = _legacyStorage.ReadFromFile(filename);

        // Parse the legacy format and return it
        Console.WriteLine("[Adapter] Load completed!\n");
        return fileContent;
    }
}
```

**Why Adapter:**

- Makes incompatible interfaces work together
- Reuses existing legacy code without modification
- Translates method calls between different interfaces
- Provides clean integration between old and new systems

**Usage:**

```csharp
LegacyFileStorage legacyStorage = new LegacyFileStorage();
ICloudStorage cloudStorage = new FileStorageAdapter(legacyStorage);
cloudStorage.SaveToCloud("Player1", 2500); // Uses legacy system internally
```

---

## Running the Project

### Commands:

```bash
cd lab3/StructuralPatterns
dotnet run
```

---

## Output

```
==========1. FACADE PATTERN==========

[Facade] Starting game - simplified interface
  [Graphics] Initializing graphics engine...
  [Graphics] Loading textures...
  [Audio] Initializing audio system...
  [Audio] Loading sound effects...
  [Input] Initializing input manager...
  [Input] Detecting controllers...
  [Network] Initializing network...
  [Network] Connecting to game server...
[Facade] Game started successfully!

Running game frame:
  [Graphics] Rendering frame...
  [Audio] Playing background music...

==========2. DECORATOR PATTERN==========
Weapon: Basic Sword
Damage: 10

Weapon: Basic Sword + Fire Enchantment
Damage: 25

Weapon: Basic Sword + Fire Enchantment + Poison Coating
Damage: 33

Weapon: Basic Sword + Fire Enchantment + Poison Coating + Sharpened Edge
Damage: 38

==========3. ADAPTER PATTERN==========
[Adapter] Converting cloud save request to file operation...
  [Legacy] Writing to file: Player1.dat
  [Legacy] Data: PlayerData: Score=2500
[Adapter] Save completed!

[Adapter] Converting cloud load request to file operation...
  [Legacy] Reading from file: Player1.dat
[Adapter] Load completed!

Retrieved: PlayerData: Score=1000
```

## Conclusions:

1. **Facade Pattern**:

   - Provides unified interface to complex subsystems
   - Reduces coupling between client and subsystems
   - Makes subsystems easier to use and understand
   - Useful for game engines, API wrappers, complex libraries

2. **Decorator Pattern**:

   - Adds responsibilities to objects dynamically
   - More flexible than static inheritance
   - Avoids feature-laden classes high in hierarchy
   - Perfect for adding abilities, effects, or enhancements

3. **Adapter Pattern**:

   - Bridges incompatible interfaces without modifying existing code
   - Enables integration of legacy systems with modern code
   - Promotes code reuse and maintainability
   - Essential for working with third-party libraries or old systems

---
