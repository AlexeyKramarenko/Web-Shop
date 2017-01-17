using ApplicationCore.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.DAL;
using ApplicationCore.DomainModel;

namespace Infrastructure
{
    public class MessageService : IMessageService
    {
        public OperationResult SendMessage(Message msg)
        {
            return new OperationResult { Succeded = true };
        }
    }
}
