using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebShop.DAL.POCO
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        [Required, StringLength(30)]
        public string DeliveryService { get; set; }

        public double DeliveryPrice { get; set; }
    }
}
