using WebShop.DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Admin.Models
{
    public class OrderViewModel
    { 
        public int OrderID { get; set; } 
        public string Customer { get; set; }  
        public string Country { get; set; } 
        public string Town { get; set; } 
        public string Email { get; set; } 
        public string Comment { get; set; }
        public string PhoneNumber { get; set; } 
        public double SummaryPrice { get; set; }
        public string DeliveryService { get; set; }
        public DateTime OrderDate { get; set; }
        public List<WebShop.Admin.Models.OrderedProductViewModel> OrderedItems { get; set; }
    }
}
