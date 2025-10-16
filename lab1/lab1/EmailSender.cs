namespace SOLIDDemo
{
    // Single Responsibility Principle: This class has ONE job - sending emails
    public class EmailSender : INotificationSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[EMAIL] Sending to {recipient}: {message}");
            // In real application, this would use SMTP to send actual emails
        }
    }
}
