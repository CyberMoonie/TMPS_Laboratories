using SOLIDDemo;

// ============================================
// SOLID Principles Demo: S, O, L
// ============================================


// ============================================
// SINGLE RESPONSIBILITY PRINCIPLE (S)
// ============================================
// Each class has ONE job and ONE reason to change
Console.WriteLine("1. SINGLE RESPONSIBILITY PRINCIPLE");
Console.WriteLine("   Each sender class has only one job:\n");

var emailSender = new EmailSender();
emailSender.Send("Your order is ready!", "user@example.com");

var smsSender = new SmsSender();
smsSender.Send("Your code is 1234", "+1234567890");

var pushSender = new PushNotificationSender();
pushSender.Send("New message received", "device_token_123");

Console.WriteLine();

// ============================================
// OPEN/CLOSED PRINCIPLE (O)
// ============================================
// NotificationService is open for extension (we can add new sender types)
// but closed for modification (we don't need to change NotificationService class)
Console.WriteLine("2. OPEN/CLOSED PRINCIPLE");
Console.WriteLine("   NotificationService can use any sender without modification:\n");

var senders = new List<INotificationSender>
{
    new EmailSender(),
    new SmsSender()
};

var notificationService = new NotificationService(senders);
notificationService.NotifyAll("Welcome to our app!", "john@example.com");

Console.WriteLine();

// ============================================
// LISKOV SUBSTITUTION PRINCIPLE (L)
// ============================================
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
