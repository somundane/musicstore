using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Item
    {
        public int SKU { get; set; }
        public string album_title { get; set; }
        public string artist { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public byte[] cover { get; set; }
    }
}