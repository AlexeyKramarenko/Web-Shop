using WebShop.DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.DAL.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        Order GetOrderByID(int orderId);
        void AddOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrdersByDate(DateTime from, DateTime to);
        IEnumerable<Order> GetOrdersByLastName(string nameStartedWith);
        IEnumerable<Order> GetOrdersByTown(string town);
        IEnumerable<Order> GetOrdersByProductMaterial(string material);
        double GetDeliveryPriceById(int deliveryId);
        IEnumerable<Delivery> GetDeliveryServices();
        int Save();
        void RemoveOrder(int orderId);
        string GetDeliveryServiceByID(int deliveryID);
    }
}
