using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class ProductEntry
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int ProductCount { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntrySerialNumber { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
