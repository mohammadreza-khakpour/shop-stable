using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public class GetOneSalesCheckListDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime RecordDate { get; set; }
        public int OverAllProductCount { get; set; }
        public double OverAllProductPrice { get; set; }
        public List<GetSalesItemDto> SalesItems { get; set; }
    }
}
