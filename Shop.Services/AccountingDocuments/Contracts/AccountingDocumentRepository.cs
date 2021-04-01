using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentRepository
    {
        void Add(int checklistId);
        GetAccountingDocumentDto FindOneById(int id);
        List<GetAccountingDocumentDto> GetAll();
    }
}
