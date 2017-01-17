using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebShop.DAL.POCO
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, StringLength(100)]
        public string LargeImgPath { get; set; }

        [Required, StringLength(100)]
        public string ThumbImgPath { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(10000)]
        public string Description { get; set; }
        [Required, StringLength(50)]
        public string SKU { get; set; } 
        public double PricePerMeter { get; set; }
        public double Diameter { get; set; } 

        public int MaterialID { get; set; }

        [ForeignKey("MaterialID")]
        public virtual Material Material { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
