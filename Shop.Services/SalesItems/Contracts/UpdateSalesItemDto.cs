using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public class UpdateSalesItemDto
    {
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public int SalesChecklistId { get; set; }
    }
}
