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

## All Structural Patterns Explained

### 1. Adapter (Implemented)

**What:** Converts one interface to another that clients expect.  
**Use when:** Need to use existing class with incompatible interface.  
**Example:** Integrating legacy payment system with new API, power plug adapter.

### 2. Bridge

**What:** Separates abstraction from implementation so both can vary independently.  
**Use when:** Want to avoid permanent binding between abstraction and implementation.  
**Example:** Remote control (abstraction) works with different devices (implementation).

### 3. Composite

**What:** Composes objects into tree structures to represent part-whole hierarchies.  
**Use when:** Want to treat individual objects and compositions uniformly.  
**Example:** File system (files and folders), UI components, organization charts.

### 4. Decorator (Implemented)

**What:** Adds new functionality to objects dynamically without altering structure.  
**Use when:** Need to add responsibilities to objects without affecting others.  
**Example:** Coffee with milk/sugar, text formatting, weapon enhancements.

### 5. Facade (Implemented)

**What:** Provides simplified, unified interface to complex subsystems.  
**Use when:** Need simple interface to complex system with many dependencies.  
**Example:** Computer startup process, home theater system, API wrappers.

### 6. Flyweight

**What:** Shares objects to support large numbers efficiently, minimizing memory.  
**Use when:** Need many similar objects, most state can be made extrinsic.  
**Example:** Text editor characters, game particles, tree rendering in forests.

### 7. Proxy

**What:** Provides placeholder/surrogate to control access to another object.  
**Use when:** Need lazy initialization, access control, or remote object access.  
**Example:** Virtual proxy for images, protection proxy for resources, caching.

---

## Implemented Patterns Details

### 1. Facade Pattern

### Theory:

> Provides a simplified, unified interface to a complex subsystem. Hides complexity behind a single interface.

**Use when:** You have multiple complex subsystems that need to work together, and you want to provide a simple interface to clients.

### Key Components:

- **GraphicsEngine, AudioSystem, InputManager, NetworkManager** - Complex subsystems
- **GameFacade** - Simplified interface that coordinates all subsystems

### Code Example:

```csharp
// Facade provides simple interface
public class GameFacade
{
    private readonly GraphicsEngine _graphics;
    private readonly AudioSystem _audio;
    // ... other subsystems

    public void StartGame()
    {
        _graphics.Initialize();
        _audio.Initialize();
        // ... initialize all subsystems
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

### Key Components:

- **IWeapon** - Component interface
- **BasicSword** - Concrete component
- **WeaponDecorator** - Base decorator class
- **FireEnchantment, PoisonCoating, Sharpened** - Concrete decorators

### Code Example:

```csharp
// Component interface
public interface IWeapon
{
    string GetDescription();
    int GetDamage();
}

// Base decorator
public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon _weapon;
    public WeaponDecorator(IWeapon weapon) => _weapon = weapon;
}

// Concrete decorator
public class FireEnchantment : WeaponDecorator
{
    public override int GetDamage() => _weapon.GetDamage() + 15;
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

### Key Components:

- **ICloudStorage** - Target interface (what client expects)
- **LegacyFileStorage** - Adaptee (existing incompatible class)
- **FileStorageAdapter** - Adapter that bridges the two

### Code Example:

```csharp
// Target interface
public interface ICloudStorage
{
    void SaveToCloud(string playerName, int score);
}

// Adapter converts new interface to old implementation
public class FileStorageAdapter : ICloudStorage
{
    private readonly LegacyFileStorage _legacyStorage;

    public void SaveToCloud(string playerName, int score)
    {
        string filename = $"{playerName}.dat";
        _legacyStorage.WriteToFile(filename, $"Score={score}");
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
