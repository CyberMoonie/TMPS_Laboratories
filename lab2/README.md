# Creational Design Patterns

## What are Creational Design Patterns?

**Creational Design Patterns** deal with object creation mechanisms, trying to create objects in a manner suitable to the situation. They help make a system independent of how its objects are created, composed, and represented.

### Common Creational Patterns:

- **Singleton** - Ensures a class has only one instance with global access
- **Factory Method** - Creates objects without specifying exact classes to create
- **Abstract Factory** - Creates families of related objects without specifying concrete classes
- **Builder** - Constructs complex objects step by step with method chaining
- **Prototype** - Creates new objects by cloning existing instances

### Patterns Used in This Laboratory: **Singleton, Factory Method, Builder**

---

## 1. Singleton Pattern

### Theory:

> Ensures only ONE instance of a class exists throughout the application's lifetime. Provides global access point.

**Use when:** You need exactly one instance (config managers, loggers, database connections).

### Implementation:

#### GameConfig.cs

```csharp
namespace CreationalPatterns.Domain
{
    public sealed class GameConfig
    {
        private static GameConfig _instance;
        private static readonly object _lock = new object();

        public string GameName { get; private set; }
        public string Version { get; private set; }
        public int MaxPlayers { get; private set; }

        private GameConfig()
        {
            GameName = "Fantasy RPG";
            Version = "1.0.0";
            MaxPlayers = 4;
        }

        public static GameConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GameConfig();
                        }
                    }
                }
                return _instance;
            }
        }

        public void DisplayConfig()
        {
            Console.WriteLine($"Game: {GameName} v{Version}");
            Console.WriteLine($"Max Players: {MaxPlayers}");
        }
    }
}
```

**Why Singleton:**

- Only ONE game configuration exists
- Private constructor prevents external instantiation
- Thread-safe double-check locking ensures single instance
- Global access through `GameConfig.Instance`

**Usage:**

```csharp
var config1 = GameConfig.Instance;
var config2 = GameConfig.Instance;
// config1 and config2 reference the SAME object
```

---

## 2. Factory Method Pattern

### Theory:

> Defines an interface for creating objects but lets subclasses decide which class to instantiate. Delegates object creation.

**Use when:** Creating different types of related objects (Warrior, Mage, Archer).

### Implementation:

#### CharacterFactory.cs

```csharp
using CreationalPatterns.Models;

namespace CreationalPatterns.Factory
{
    public abstract class CharacterFactory
    {
        public abstract Character CreateCharacter(string name);
    }

    public class WarriorFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            return new Character
            {
                Name = name,
                Class = "Warrior",
                Health = 150,
                Mana = 50,
                Weapon = "Sword",
                Armor = "Heavy Armor",
                Accessory = "Shield"
            };
        }
    }

    public class MageFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            return new Character
            {
                Name = name,
                Class = "Mage",
                Health = 80,
                Mana = 200,
                Weapon = "Staff",
                Armor = "Robe",
                Accessory = "Magic Ring"
            };
        }
    }

    public class ArcherFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            return new Character
            {
                Name = name,
                Class = "Archer",
                Health = 100,
                Mana = 100,
                Weapon = "Bow",
                Armor = "Leather Armor",
                Accessory = "Quiver"
            };
        }
    }
}
```

**Why Factory Method:**

- Encapsulates character creation logic
- Each factory produces a specific character type
- Easy to add new character types without modifying existing code
- Consistent character stats per type

**Usage:**

```csharp
CharacterFactory warriorFactory = new WarriorFactory();
var warrior = warriorFactory.CreateCharacter("Aragorn");
```

---

## 3. Builder Pattern

### Theory:

> Constructs complex objects step by step. Separates object construction from representation. Allows creating different object variations.

**Use when:** Objects have many optional parameters or complex initialization steps.

### Implementation:

#### CharacterBuilder.cs

```csharp
using CreationalPatterns.Models;

namespace CreationalPatterns.Domain
{
    public class CharacterBuilder
    {
        private Character _character;

        public CharacterBuilder()
        {
            _character = new Character();
        }

        public CharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }

        public CharacterBuilder SetClass(string characterClass)
        {
            _character.Class = characterClass;
            return this;
        }

        public CharacterBuilder SetHealth(int health)
        {
            _character.Health = health;
            return this;
        }

        public CharacterBuilder SetMana(int mana)
        {
            _character.Mana = mana;
            return this;
        }

        public CharacterBuilder SetWeapon(string weapon)
        {
            _character.Weapon = weapon;
            return this;
        }

        public CharacterBuilder SetArmor(string armor)
        {
            _character.Armor = armor;
            return this;
        }

        public CharacterBuilder SetAccessory(string accessory)
        {
            _character.Accessory = accessory;
            return this;
        }

        public Character Build()
        {
            return _character;
        }

        public void Reset()
        {
            _character = new Character();
        }
    }
}
```

**Why Builder:**

- Constructs complex Character objects step by step
- Method chaining provides readable, fluent API
- Flexible - set only needed properties
- Separates construction logic from representation

**Usage:**

```csharp
var builder = new CharacterBuilder();
var character = builder
    .SetName("Custom Hero")
    .SetClass("Paladin")
    .SetHealth(130)
    .SetMana(120)
    .SetWeapon("Holy Sword")
    .SetArmor("Blessed Armor")
    .SetAccessory("Divine Amulet")
    .Build();
```

---

## Character Model

#### Character.cs

```csharp
namespace CreationalPatterns.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public string Weapon { get; set; }
        public string Armor { get; set; }
        public string Accessory { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n=== Character Info ===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Weapon: {Weapon}");
            Console.WriteLine($"Armor: {Armor}");
            Console.WriteLine($"Accessory: {Accessory}");
            Console.WriteLine($"====================\n");
        }
    }
}
```

---

## Running the Project

### Commands:

```bash
cd lab2/CreationalPatterns
dotnet run
```

---

## Output

```
=== CREATIONAL DESIGN PATTERNS DEMO ===

--- PATTERN 1: SINGLETON ---
Game: Fantasy RPG v1.0.0
Max Players: 4
Same instance? True

--- PATTERN 2: FACTORY METHOD ---

=== Character Info ===
Name: Aragorn
Class: Warrior
Health: 150
Mana: 50
Weapon: Sword
Armor: Heavy Armor
Accessory: Shield
====================


=== Character Info ===
Name: Gandalf
Class: Mage
Health: 80
Mana: 200
Weapon: Staff
Armor: Robe
Accessory: Magic Ring
====================


=== Character Info ===
Name: Legolas
Class: Archer
Health: 100
Mana: 100
Weapon: Bow
Armor: Leather Armor
Accessory: Quiver
====================

--- PATTERN 3: BUILDER ---

=== Character Info ===
Name: Custom Hero
Class: Paladin
Health: 130
Mana: 120
Weapon: Holy Sword
Armor: Blessed Armor
Accessory: Divine Amulet
====================
```

## Conclusions

### Pattern Comparison:

| Pattern       | Purpose                   | When to Use                         |
| ------------- | ------------------------- | ----------------------------------- |
| **Singleton** | ONE instance globally     | Config, logger, game manager        |
| **Factory**   | Create object variations  | Multiple related types (characters) |
| **Builder**   | Construct complex objects | Many parameters, step-by-step build |

### Conclusions:

1. **Singleton Pattern**:

   - Guarantees single instance across application
   - Thread-safe implementation prevents race conditions
   - Useful for shared resources (configuration, connections)

2. **Factory Method Pattern**:

   - Delegates object creation to specialized factories
   - Promotes loose coupling and extensibility
   - Easy to add new types without modifying existing code

3. **Builder Pattern**:

   - Provides fluent, readable object construction
   - Separates complex construction from representation
   - Ideal for objects with many optional parameters

---
