namespace SOLIDDemo
{
    // Single Responsibility Principle: This class has ONE job - sending SMS
    public class SmsSender : INotificationSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[SMS] Sending to {recipient}: {message}");
        }
    }
}
