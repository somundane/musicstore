using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Sale
    {
        public int sales_no { get; set; }
        public int SKU { get; set; }
        public decimal price { get; set; }
        public int qty_sold { get; set; }
        public int user_id { get; set; }
    }
}