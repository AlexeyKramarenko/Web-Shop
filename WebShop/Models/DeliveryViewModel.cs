using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Models
{
    public class DeliveryViewModel
    {
        public string DeliveryService { get; set; }
        public double DeliveryPrice { get; set; }
        public double SummaryPrice { get; set; }
    }
}
