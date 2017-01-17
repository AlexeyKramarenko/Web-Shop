using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebShop.DAL.POCO
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(30)]
        public string Country { get; set; }
        [Required, StringLength(30)]
        public string Town { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string Comment { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name = "Price")]
        public double? SummaryPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderItem> OrderedItems { get; set; }
        public int DeliveryID { get; set; }
        [ForeignKey("DeliveryID")]
        public Delivery Delivery { get; set; }
    }
}
