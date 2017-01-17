using WebShop.DAL;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ApplicationServices
{     
    public interface IOrderService
    {
        OperationResult SendOrder(Order order);
    }
}
