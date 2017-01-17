using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Models
{
    public class ProductDetailsViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string LargeImgPath { get; set; }
        public double Diameter { get; set; }
    }
}
