using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebShop.DAL.POCO
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }

        [Required, StringLength(50)]
        public string MaterialName { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
