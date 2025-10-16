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
