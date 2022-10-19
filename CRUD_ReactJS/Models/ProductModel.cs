using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_ReactJS.Models
{
    public class ProductModel
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> product_price { get; set; }
        public Nullable<decimal> product_discount { get; set; }
        public string Type { get; set; }
    }
}