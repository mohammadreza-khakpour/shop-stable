using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class SalesCheckList
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime RecordDate { get; set; }
        public int OverAllProductCount { get; set; }
        public double OverAllProductPrice { get; set; }
        public HashSet<SalesItem> Items { get; set; } = new HashSet<SalesItem>();
    }
}
