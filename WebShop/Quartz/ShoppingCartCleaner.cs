using WebShop.SignalR;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Quartz
{
    public class ShoppingCartCleaner : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var cart = new ShoppingCart();
            cart.RemoveUnactiveCarts();
        }
    }
}
