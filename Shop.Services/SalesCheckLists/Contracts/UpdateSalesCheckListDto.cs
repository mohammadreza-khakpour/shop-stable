using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public class UpdateSalesCheckListDto
    {
        public string SerialNumber { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
