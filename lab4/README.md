# Behavioral Design Patterns

## What are Behavioral Design Patterns?

**Behavioral Design Patterns** focus on communication between objects, how objects interact and distribute responsibility. They help define how objects collaborate and how responsibilities are assigned, making the interaction between objects more flexible and easier to understand.

### Common Behavioral Patterns:

- **Chain of Responsibility** - Passes request along chain of handlers until one handles it
- **Command** - Encapsulates requests as objects for queuing, logging, or undo operations
- **Interpreter** - Defines grammar and interpreter for a language (rarely used)
- **Iterator** - Provides sequential access to collection elements without exposing structure
- **Mediator** - Centralizes complex communications between objects
- **Memento** - Captures and restores object's internal state without violating encapsulation
- **Observer** - Notifies multiple objects about state changes automatically
- **State** - Changes object behavior when internal state changes
- **Strategy** - Defines family of interchangeable algorithms
- **Template Method** - Defines algorithm skeleton, letting subclasses override specific steps
- **Visitor** - Separates algorithms from objects they operate on

### Patterns Used in This Laboratory: **Strategy, Observer, Command**

---

## All Behavioral Patterns Explained

### 1. Chain of Responsibility

**What:** Request passes through chain of handlers until one processes it.  
**Use when:** Multiple objects can handle a request, handler isn't known beforehand.  
**Example:** Support ticket system - Level 1 → Level 2 → Level 3 support.

### 2. Command ⭐ (Implemented)

**What:** Encapsulates request as object with all information needed to execute it.  
**Use when:** Need to queue operations, support undo/redo, or log requests.  
**Example:** Text editor undo/redo, transaction systems, macro recording.

### 3. Interpreter

**What:** Defines grammar representation and interpreter for a language.  
**Use when:** Need to interpret sentences in a language (SQL parser, expression evaluator).  
**Example:** Regular expressions, mathematical expression evaluator, scripting languages.

### 4. Iterator

**What:** Provides way to access collection elements sequentially without exposing structure.  
**Use when:** Need to traverse different collection types uniformly.  
**Example:** Looping through arrays, lists, trees - C#'s `foreach` uses this pattern.

### 5. Mediator

**What:** Centralizes communication between objects to reduce coupling.  
**Use when:** Objects communicate in complex ways, want to reuse objects independently.  
**Example:** Chat room (mediator) between users, air traffic control tower.

### 6. Memento

**What:** Captures and externalizes object state for later restoration.  
**Use when:** Need to save/restore object state (snapshots, checkpoints).  
**Example:** Game save states, document version history, database transactions.

### 7. Observer ⭐ (Implemented)

**What:** One-to-many dependency - when one object changes, dependents get notified.  
**Use when:** Change in one object requires changing others, number of dependents varies.  
**Example:** Event systems, data binding, social media notifications, pub/sub systems.

### 8. State

**What:** Object changes behavior when internal state changes (appears to change class).  
**Use when:** Object behavior depends on state, has large conditional statements.  
**Example:** TCP connection states, vending machine states, game character states.

### 9. Strategy ⭐ (Implemented)

**What:** Defines family of algorithms, makes them interchangeable.  
**Use when:** Many related classes differ only in behavior, need different algorithm variants.  
**Example:** Sorting algorithms, payment methods, compression algorithms, route planning.

### 10. Template Method

**What:** Defines algorithm skeleton, subclasses override specific steps.  
**Use when:** Common algorithm structure with varying implementations in steps.  
**Example:** Framework hooks, data mining algorithms, game AI routines.

### 11. Visitor

**What:** Separates algorithm from object structure it operates on.  
**Use when:** Many distinct operations on object structure, avoid polluting classes.  
**Example:** Compiler operations (type checking, code generation), report generation.

---

## Implemented Patterns

### 1. Strategy Pattern

**Key Components:**

- **IAttackStrategy** - Strategy interface defining attack behavior
- **MeleeAttack, RangedAttack, MagicAttack** - Concrete strategies
- **Player** - Context that uses strategy

**How it works:**  
Player can switch between different attack strategies at runtime. Each strategy encapsulates a specific attack algorithm.

**Benefits:**

- Algorithms interchangeable at runtime
- Eliminates conditional statements
- Easy to add new strategies

---

### 2. Observer Pattern

**Key Components:**

- **IObserver/ISubject** - Observer and Subject interfaces
- **PlayerActions** - Subject that triggers events
- **AchievementSystem, StatisticsTracker, NotificationService** - Observers

**How it works:**  
When player performs actions (kill enemy, collect item), all registered observers are automatically notified and can react independently.

**Benefits:**

- Loose coupling between subject and observers
- Dynamic subscription/unsubscription
- Broadcast communication

---

### 3. Command Pattern

**Key Components:**

- **ICommand** - Command interface with Execute/Undo
- **AttackCommand, MoveCommand** - Concrete commands
- **GameCharacter** - Receiver that performs actions
- **CommandInvoker** - Manages command execution and history

**How it works:**  
Actions are encapsulated as command objects that can be executed, queued, and undone. Command history allows reversing operations.

**Benefits:**

- Supports undo/redo operations
- Commands can be queued and logged
- Decouples sender from receiver

---

## Running the Project

```bash
cd lab4/BehavioralPatterns
dotnet run
```

---

## Output

```
========================================
  BEHAVIORAL DESIGN PATTERNS DEMO
========================================

==========1. STRATEGY PATTERN==========

  [Melee] Slashing Goblin with sword! Damage: 50
[Hero] Changed attack strategy to RangedAttack
  [Ranged] Shooting Dragon with bow! Damage: 30
[Hero] Changed attack strategy to MagicAttack
  [Magic] Casting fireball at Boss! Damage: 80

==========2. OBSERVER PATTERN==========
[Observer] AchievementSystem attached
[Observer] StatisticsTracker attached
[Observer] NotificationService attached

[Hero] Killed an enemy!
  [Achievement] Event received: EnemyKilled - Checking achievements...
  [Statistics] Recording: EnemyKilled
  [Notification] Sending notification for: EnemyKilled

[Hero] Collected an item!
  [Achievement] Event received: ItemCollected - Checking achievements...
  [Statistics] Recording: ItemCollected
  [Notification] Sending notification for: ItemCollected

==========3. COMMAND PATTERN==========

Initial state - Health: 100, Position: (0, 0)

[Command] Executing Move
  Character moved to (5, 3)
[Command] Executing Attack
  Character took 20 damage. Health: 80
[Command] Executing Move
  Character moved to (3, 7)

--- Undoing commands ---

[Command] Undoing Move
  Character moved to (5, 3)
[Command] Undoing Attack
  Character healed 20. Health: 100
[Command] Undoing Move
  Character moved to (0, 0)

========================================
  DEMO COMPLETED
========================================
```

---

## Conclusions

1. **Strategy Pattern**:

   - Enables selecting algorithm at runtime
   - Eliminates complex conditionals
   - Makes adding new behaviors easy without modifying existing code

2. **Observer Pattern**:

   - Establishes one-to-many relationships
   - Subjects and observers remain loosely coupled
   - Foundation for event-driven architectures and reactive programming

3. **Command Pattern**:
   - Treats requests as first-class objects
   - Provides powerful undo/redo mechanism
   - Enables request queuing, logging, and transaction management

---
