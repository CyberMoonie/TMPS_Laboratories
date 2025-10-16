# SOLID Principles Demo Project

## 📚 What is SOLID?

**SOLID** is an acronym for five design principles that make software designs more understandable, flexible, and maintainable. These principles were introduced by Robert C. Martin (Uncle Bob).

### The Five SOLID Principles:

- **S** - Single Responsibility Principle
- **O** - Open/Closed Principle
- **L** - Liskov Substitution Principle
- **I** - Interface Segregation Principle
- **D** - Dependency Inversion Principle

### ✅ Principles Used in This Project: **S, O, L**

---

## 🎯 1. Single Responsibility Principle (S)

### Theory:

> "A class should have one, and only one, reason to change."

Each class should have a single responsibility or purpose. If a class has multiple responsibilities, changes to one responsibility might affect the others.

### Implementation:

We created separate classes for each notification type, each with a single responsibility:

#### INotificationSender.cs (Interface)

```csharp
namespace SOLIDDemo
{
    // Interface for sending notifications
    public interface INotificationSender
    {
        void Send(string message, string recipient);
    }
}
```

#### EmailSender.cs

```csharp
namespace SOLIDDemo
{
    // Single Responsibility: This class has ONE job - sending emails
    public class EmailSender : INotificationSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[EMAIL] Sending to {recipient}: {message}");
            // In real application, this would use SMTP to send actual emails
        }
    }
}
```

#### SmsSender.cs

```csharp
namespace SOLIDDemo
{
    // Single Responsibility: This class has ONE job - sending SMS
    public class SmsSender : INotificationSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[SMS] Sending to {recipient}: {message}");
            // In real application, this would use SMS API
        }
    }
}
```

#### PushNotificationSender.cs

```csharp
namespace SOLIDDemo
{
    // Single Responsibility: This class has ONE job - sending push notifications
    public class PushNotificationSender : INotificationSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[PUSH] Sending to {recipient}: {message}");
            // In real application, this would use push notification service
        }
    }
}
```

**Why this follows SRP:**

- Each sender class has exactly ONE reason to change
- If email logic changes, only `EmailSender` needs modification
- If SMS logic changes, only `SmsSender` needs modification
- No class is responsible for multiple unrelated concerns

---

## 🔓 2. Open/Closed Principle (O)

### Theory:

> "Software entities should be open for extension, but closed for modification."

Classes should be designed so you can add new functionality without changing existing code. Use abstractions (interfaces) to achieve this.

### Implementation:

#### NotificationService.cs

```csharp
namespace SOLIDDemo
{
    // Open/Closed Principle: This class is open for extension (can add new notification types)
    // but closed for modification (we don't need to change this class when adding new types)
    public class NotificationService
    {
        private readonly List<INotificationSender> _senders;

        // Constructor: Accepts a list of senders
        public NotificationService(List<INotificationSender> senders)
        {
            _senders = senders;
        }

        // Send notification using all registered senders
        public void NotifyAll(string message, string recipient)
        {
            foreach (var sender in _senders)
            {
                sender.Send(message, recipient);
            }
        }
    }
}
```

**Why this follows OCP:**

- `NotificationService` works with the `INotificationSender` interface
- We can add new sender types (e.g., `WhatsAppSender`, `TelegramSender`) WITHOUT modifying `NotificationService`
- Just create a new class implementing `INotificationSender` and pass it to the service
- The class is **OPEN** for extension (new types) but **CLOSED** for modification (no code changes needed)

---

## 🔄 3. Liskov Substitution Principle (L)

### Theory:

> "Objects of a superclass should be replaceable with objects of a subclass without breaking the application."

Derived classes or implementations must be substitutable for their base types. Any class implementing an interface should work correctly wherever that interface is used.

### Implementation:

#### Program.cs (Demonstration)

```csharp
using SOLIDDemo;

Console.WriteLine("=== SOLID Principles Demo ===\n");

// LISKOV SUBSTITUTION PRINCIPLE
// Any INotificationSender can replace another without breaking the program
Console.WriteLine("3. LISKOV SUBSTITUTION PRINCIPLE");
Console.WriteLine("   All senders can be used interchangeably:\n");

// We can use any sender where INotificationSender is expected
INotificationSender sender1 = new EmailSender();
INotificationSender sender2 = new SmsSender();
INotificationSender sender3 = new PushNotificationSender();

// All work the same way - they're substitutable
SendNotification(sender1, "Test message 1", "recipient1");
SendNotification(sender2, "Test message 2", "recipient2");
SendNotification(sender3, "Test message 3", "recipient3");

// Helper method that accepts any INotificationSender
static void SendNotification(INotificationSender sender, string message, string recipient)
{
    sender.Send(message, recipient);
}
```

**Why this follows LSP:**

- All three classes (`EmailSender`, `SmsSender`, `PushNotificationSender`) implement `INotificationSender`
- They can be used interchangeably wherever `INotificationSender` is expected
- The `SendNotification` method works correctly with ANY implementation
- Substituting one sender for another doesn't break the code
- All implementations follow the same contract and behave predictably

---

## 🚀 Running the Project

### Prerequisites:

- .NET SDK 8.0 or higher

### Commands:

```bash
# Navigate to the project directory
cd SOLIDPrinciples/SOLIDDemo

# Run the application
dotnet run

# Build the application (optional)
dotnet build
```

### Expected Output:

```
=== SOLID Principles Demo ===

1. SINGLE RESPONSIBILITY PRINCIPLE
   Each sender class has only one job:

[EMAIL] Sending to user@example.com: Your order is ready!
[SMS] Sending to +1234567890: Your code is 1234
[PUSH] Sending to device_token_123: New message received

2. OPEN/CLOSED PRINCIPLE
   NotificationService can use any sender without modification:

[EMAIL] Sending to john@example.com: Welcome to our app!
[SMS] Sending to john@example.com: Welcome to our app!

3. LISKOV SUBSTITUTION PRINCIPLE
   All senders can be used interchangeably:

[EMAIL] Sending to recipient1: Test message 1
[SMS] Sending to recipient2: Test message 2
[PUSH] Sending to recipient3: Test message 3

=== Demo Complete ===
```

---

## 📂 Project Structure

```
SOLIDPrinciples/
├── README.md
└── SOLIDDemo/
    ├── Program.cs                      # Main entry point
    ├── INotificationSender.cs          # Interface definition
    ├── EmailSender.cs                  # Email implementation (S)
    ├── SmsSender.cs                    # SMS implementation (S)
    ├── PushNotificationSender.cs       # Push notification implementation (S)
    ├── NotificationService.cs          # Service using the interface (O)
    └── SOLIDDemo.csproj                # Project file
```

---

## 💡 Key Takeaways

1. **Single Responsibility (S)**: Each class has one clear purpose

   - Easy to understand and maintain
   - Changes are isolated to specific classes

2. **Open/Closed (O)**: Extend functionality without modifying existing code

   - Add new notification types without touching `NotificationService`
   - Use interfaces for flexibility

3. **Liskov Substitution (L)**: All implementations are interchangeable
   - Code works with the interface, not specific implementations
   - Any sender can be swapped for another

---

## 🎓 Learning Resources

- [SOLID Principles by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2020/10/18/Solid-Relevance.html)
- [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/)

---

**Author:** SOLID Principles Demo  
**Date:** October 15, 2025  
**Framework:** .NET 8.0
