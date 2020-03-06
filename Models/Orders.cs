using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Orders
    {
        public int order_no { get; set; }
        public int SKU { get; set; }
        public int qty_ordered { get; set; }
        public string order_status { get; set; }
        public DateTime date_ordered { get; set; }
        public DateTime delivery_date { get; set; }
    }
}