using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public class AddSalesItemDto
    {
        public int ProductCount { get; set; }
        public string ProductCode { get; set; }
        public double ProductPrice { get; set; }
        public int ProductId { get; set; }
    }
}
