using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public class GetSalesItemDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public int SalesChecklistId { get; set; }
    }
}
