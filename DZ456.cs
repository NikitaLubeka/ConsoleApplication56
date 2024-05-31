using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp38
{
    public class OrderPlacement
    {
        public void PlaceOrder(string product, int quantity)
        {
            Console.WriteLine($"Заказ оформлен на {quantity} ед. товара {product}.");
        }
    }

    public class OrderTracking
    {
        private Dictionary<int, string> orderStatuses = new Dictionary<int, string>
    {
        {1, "В обработке"},
        {2, "Отправлен"},
        {3, "Доставлен"}
    };

        public string CheckOrderStatus(int orderId)
        {
            return orderStatuses.ContainsKey(orderId) ? orderStatuses[orderId] : "Заказ не найден";
        }
    }

    public class NotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Уведомление отправлено: {message}");
        }
    }

    public class OrderFacade
    {
        private OrderPlacement _orderPlacement;
        private OrderTracking _orderTracking;
        private NotificationService _notificationService;

        public OrderFacade()
        {
            _orderPlacement = new OrderPlacement();
            _orderTracking = new OrderTracking();
            _notificationService = new NotificationService();
        }

        public void PlaceOrder(string product, int quantity)
        {
            _orderPlacement.PlaceOrder(product, quantity);
            _notificationService.SendNotification("Ваш заказ был оформлен.");
        }

        public void CheckOrderStatus(int orderId)
        {
            var status = _orderTracking.CheckOrderStatus(orderId);
            Console.WriteLine($"Статус заказа {orderId}: {status}");
        }
    }

    public abstract class Order
    {
        protected IOrderProcessor _orderProcessor;

        protected Order(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public abstract void ProcessOrder(string product, int quantity);
    }

    public interface IOrderProcessor
    {
        void Process(string product, int quantity);
    }

    public class StandardOrderProcessor : IOrderProcessor
    {
        public void Process(string product, int quantity)
        {
            Console.WriteLine($"Обработка стандартного заказа на {quantity} ед. товара {product}.");
        }
    }

    public class OnlineOrder : Order
    {
        public OnlineOrder(IOrderProcessor orderProcessor) : base(orderProcessor) { }

        public override void ProcessOrder(string product, int quantity)
        {
            _orderProcessor.Process(product, quantity);
        }
    }

    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification
    {
        public void SendEmail(string emailMessage)
        {
            Console.WriteLine($"Email отправлен: {emailMessage}");
        }
    }

    public class EmailNotificationAdapter : INotification
    {
        private EmailNotification _emailNotification;

        public EmailNotificationAdapter(EmailNotification emailNotification)
        {
            _emailNotification = emailNotification;
        }

        public void Send(string message)
        {
            _emailNotification.SendEmail(message);
        }
    }

    class Program
    {
        static void Main()
        {
            OrderFacade orderFacade = new OrderFacade();
            orderFacade.PlaceOrder("Ноутбук", 1);
            orderFacade.CheckOrderStatus(1);

            IOrderProcessor standardOrderProcessor = new StandardOrderProcessor();
            Order onlineOrder = new OnlineOrder(standardOrderProcessor);
            onlineOrder.ProcessOrder("Смартфон", 2);

            EmailNotification emailNotification = new EmailNotification();
            INotification notification = new EmailNotificationAdapter(emailNotification);
            notification.Send("Ваш заказ был отправлен.");
        }
    }
