namespace BehavioralPatterns.Observer;

// Observer interface
public interface IObserver
{
    void Update(string eventMessage);
}

// Subject interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string message);
}

// Concrete Subject
public class PlayerActions : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    public string PlayerName { get; set; }

    public PlayerActions(string playerName)
    {
        PlayerName = playerName;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine($"[Observer] {observer.GetType().Name} attached");
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }

    public void KillEnemy()
    {
        Console.WriteLine($"\n[{PlayerName}] Killed an enemy!");
        Notify("EnemyKilled");
    }

    public void CollectItem()
    {
        Console.WriteLine($"\n[{PlayerName}] Collected an item!");
        Notify("ItemCollected");
    }
}

// Concrete Observers
public class AchievementSystem : IObserver
{
    public void Update(string eventMessage)
    {
        Console.WriteLine($"  [Achievement] Event received: {eventMessage} - Checking achievements...");
    }
}

public class StatisticsTracker : IObserver
{
    public void Update(string eventMessage)
    {
        Console.WriteLine($"  [Statistics] Recording: {eventMessage}");
    }
}

public class NotificationService : IObserver
{
    public void Update(string eventMessage)
    {
        Console.WriteLine($"  [Notification] Sending notification for: {eventMessage}");
    }
}
