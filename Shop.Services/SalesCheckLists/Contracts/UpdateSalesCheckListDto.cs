using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public class UpdateSalesCheckListDto
    {
        public string SerialNumber { get; set; }
        public string RecordDate { get; set; }
        public string CustomerFullName { get; set; }
        public List<AddSalesItemDto> SalesItems { get; set; }
    }
}
