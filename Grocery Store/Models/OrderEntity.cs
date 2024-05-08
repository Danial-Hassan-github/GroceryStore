﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery_Store.Models
{
    public class OrderEntity
    {
        public int id { set; get; }
        public int pid { set; get; }
        public string pName { set; get; }
        public double price { set; get; }
        public int quantity { set; get; }
        public string address { set; get; }
        public double bill { set; get; }
        public string contact { set; get; }
    }
}