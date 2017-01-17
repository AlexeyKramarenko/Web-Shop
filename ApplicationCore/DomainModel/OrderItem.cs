using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebShop.DAL.POCO
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string SKU { get; set; }
        public double PricePerItem { get; set; } 
        public int Amount { get; set; }        
        public double Price { get; set; }
        public int Length { get; set; }
        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
    }
}
