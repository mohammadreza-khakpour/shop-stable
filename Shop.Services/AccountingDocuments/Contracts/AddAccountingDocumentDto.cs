using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.AccountingDocuments.Contracts
{
    public class AddAccountingDocumentDto
    {
        public DateTime CreationDate { get; set; }
        public string SerialNumber { get; set; }
        public int SalesCheckListId { get; set; }
    }
}
