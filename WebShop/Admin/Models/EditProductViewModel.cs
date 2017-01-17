using WebShop.DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Admin.Models
{
    public class EditProductViewModel
    {
        public int ProductID { get; set; }       
        public string LargeImgPath { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public double PricePerMeter { get; set; }
        public int MaterialID { get; set; }
        public List<Material> Materials { get; set; }
              

    }
}
