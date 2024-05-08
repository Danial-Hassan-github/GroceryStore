using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery_Store.Models
{
    public class ProductEntity
    {
        public int id { set; get; }
        public string ptitle { set; get; }
        public string category { set; get; }
        public double price { set; get; }
        public int quantity{ set; get; }
        public string image { set; get; }
        public string imageType { set; get; }
        public HttpPostedFileBase fileAttachment { set; get; }
    }
}