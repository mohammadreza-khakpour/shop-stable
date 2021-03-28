using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentRepository
    {
        int Add(AccountingDocument accountingDocument);
        void Delete(int id);
        AccountingDocument Find(int id);
        GetAccountingDocumentDto FindOneById(int id);
        List<GetAccountingDocumentDto> GetAll();
    }
}
