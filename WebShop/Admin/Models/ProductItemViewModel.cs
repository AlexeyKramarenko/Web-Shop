using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Admin.Models
{
    public class ProductItemViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string MaterialName { get; set; }
        public string ThumbImgPath { get; set; }
    }
}
