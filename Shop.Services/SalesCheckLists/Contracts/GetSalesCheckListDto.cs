using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public class GetSalesCheckListDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
