using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Admin.Models
{
    public class OrderItemViewModel
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
    }
}
