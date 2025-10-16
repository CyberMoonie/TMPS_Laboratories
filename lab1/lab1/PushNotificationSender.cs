namespace SOLIDDemo
{
    // Single Responsibility Principle: This class has ONE job - sending push notifications
    public class PushNotificationSender : INotificationSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[PUSH] Sending to {recipient}: {message}");
            // In real application, this would use push notification service
        }
    }
}
