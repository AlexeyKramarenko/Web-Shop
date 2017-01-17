using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.Models
{
    public class ProductItemViewModel
    {
        public int ProductID { get; set; }
        public string ThumbImgPath { get; set; }
        public double PricePerMeter { get; set; }
        public double Diameter { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string MaterialName { get; set; }
    }

    public class FilterViewModel
    {
        public short ItemsPerPage { get; set; }
        public string SortParameter { get; set; }
        public string Material { get; set; }
    }

}
