using WebShop.DAL.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebShop.Admin.Models
{
    public class NewProductViewModel
    {
        [Required]
        public int Diameter { get; set; } 
        public string LargeImgPath { get; set; } 
        public string ThumbImgPath { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public double? PricePerMeter { get; set; }
        public int MaterialID { get; set; }
        public List<Material> Materials { get; set; }
    }
}
