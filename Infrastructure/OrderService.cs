using ApplicationCore.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.DAL;
using WebShop.DAL.POCO;
using WebShop.DAL.Interfaces;
using ApplicationCore.DomainModel;

namespace Infrastructure
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        IMessageService messageService;

        public OrderService(IOrderRepository orderRepository, IMessageService messageService)
        {
            this.orderRepository = orderRepository;
            this.messageService = messageService;
        }
        public OperationResult SendOrder(Order order)
        {
            try
            {
                orderRepository.AddOrder(order);
                orderRepository.Save();

                var msg = new Message
                {
                    Email = order.Email,
                    Text = order.Comment,
                    UserName = order.FirstName + " " + order.LastName
                };
                OperationResult result = messageService.SendMessage(msg);
                return result;
            }
            catch (Exception e)
            {
                return new OperationResult { Succeded = false, Message = "Возникли проблемы при попытке отправить сообщение. Попробуйте позже." };
            }
        }
        
    }
}
