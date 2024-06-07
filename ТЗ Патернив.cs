using System;
using System;
using System.Collections.Generic;

public interface IMessage
{
    void Send(string recipient, string content);
}

public class EmailMessage : IMessage
{
    public void Send(string recipient, string content)
    {
        Console.WriteLine("Sending Email to {recipient}: {content}");
    }
}

public class SmsMessage : IMessage
{
    public void Send(string recipient, string content)
    {
        Console.WriteLine("Sending SMS to {recipient}: {content}");
    }
}
public abstract class MessageFactory
{
    public abstract IMessage CreateMessage();
}

public class EmailMessageFactory : MessageFactory
{
    public override IMessage CreateMessage()
    {
        return new EmailMessage();
    }
}

public class SmsMessageFactory : MessageFactory
{
    public override IMessage CreateMessage()
    {
        return new SmsMessage();
    }
}
public interface ISubscriber
{
    void Update(IMessage message, string recipient, string content);
}

public class NotificationManager
{
    private List<ISubscriber> subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void Notify(IMessage message, string recipient, string content)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber.Update(message, recipient, content);
        }
    }
}

public class MessageSubscriber : ISubscriber
{
    public void Update(IMessage message, string recipient, string content)
    {
        message.Send(recipient, content);
    }
}
public class MessageFacade
{
    private NotificationManager notificationManager = new NotificationManager();
    private MessageFactory emailFactory = new EmailMessageFactory();
    private MessageFactory smsFactory = new SmsMessageFactory();

    public void SendEmail(string recipient, string content)
    {
        IMessage message = emailFactory.CreateMessage();
        notificationManager.Notify(message, recipient, content);
    }

    public void SendSms(string recipient, string content)
    {
        IMessage message = smsFactory.CreateMessage();
        notificationManager.Notify(message, recipient, content);
    }

    public void AddSubscriber(ISubscriber subscriber)
    {
        notificationManager.Subscribe(subscriber);
    }

    public void RemoveSubscriber(ISubscriber subscriber)
    {
        notificationManager.Unsubscribe(subscriber);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        MessageFacade messageFacade = new MessageFacade();
        MessageSubscriber subscriber = new MessageSubscriber();
        messageFacade.AddSubscriber(subscriber);
        messageFacade.SendEmail("example@example.com", "Hello via Email!");
        messageFacade.SendSms("123-456-7890", "Hello via SMS!");
        messageFacade.RemoveSubscriber(subscriber);
    }
}
