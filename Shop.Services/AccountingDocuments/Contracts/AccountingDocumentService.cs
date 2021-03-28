using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentService
    {
        int Add(AddAccountingDocumentDto dto);
        void Delete(int id);
        GetAccountingDocumentDto FindOneById(int id);
        List<GetAccountingDocumentDto> GetAll();
        void Update(int id, UpdateAccountingDocumentDto dto);
    }
}
