using ApplicationCore.ApplicationServices;
using ApplicationCore.DomainModel;
using AutoMapper;
using WebShop.DAL;
using WebShop.Models;
using Ninject;

namespace WebShop
{
    public partial class Contacts : BasePage
    {
        [Inject]
        public IMessageService MessageService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        public void SendMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = Mapper.Map<MessageViewModel, Message>(model);
                OperationResult result = MessageService.SendMessage(message);
                if(!result.Succeded)
                    ModelState.AddModelError("", result.Message);
            } 

        }
    }
}