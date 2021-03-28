using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductEntries.Contracts
{
    public class UpdateProductEntryDto
    {
        public string ProductCode { get; set; }
        public int ProductCount { get; set; }
        public string EntryDate { get; set; }
        public string EntrySerialNumber { get; set; }
        public int ProductId { get; set; }
    }
}
