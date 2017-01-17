using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Models
{
    public class CartItemViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public double PricePerMeter { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int Length { get; set; }
    }
}
