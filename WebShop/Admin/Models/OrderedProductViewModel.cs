using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Admin.Models
{
    public class OrderedProductViewModel
    {
        public int OrderItemID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string ThumbImgPath { get; set; }
        public double PricePerItem { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int Length { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
