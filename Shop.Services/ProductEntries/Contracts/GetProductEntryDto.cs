using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductEntries.Contracts
{
    public class GetProductEntryDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public string ProductCode { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntrySerialNumber { get; set; }
        public int ProductId { get; set; }
    }
}
