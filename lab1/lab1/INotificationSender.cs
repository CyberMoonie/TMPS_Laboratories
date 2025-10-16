namespace SOLIDDemo
{
    // Interface for sending notifications (used for Open/Closed Principle)
    public interface INotificationSender
    {
        void Send(string message, string recipient);
    }
}
