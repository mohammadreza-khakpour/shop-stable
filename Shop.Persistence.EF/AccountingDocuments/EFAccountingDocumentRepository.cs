using Shop.Entities;
using Shop.Services.AccountingDocuments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.AccountingDocuments
{
    public class EFAccountingDocumentRepository : AccountingDocumentRepository
    {
        private EFDataContext _dBContext;
        public EFAccountingDocumentRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int Add(AccountingDocument accountingDocument)
        {
            var result = _dBContext.AccountingDocuments.Add(accountingDocument);
            return result.Entity.Id;
        }

        public void Delete(int id)
        {
            var accountingDocument = Find(id);
            _dBContext.AccountingDocuments.Remove(accountingDocument);
        }
        public AccountingDocument Find(int id)
        {
            return _dBContext.AccountingDocuments.Find(id);
        }
        public List<GetAccountingDocumentDto> GetAll()
        {
            return _dBContext.AccountingDocuments.Select(_ => new GetAccountingDocumentDto
            {
                Id = _.Id,
                CreationDate = _.CreationDate,
                SalesCheckListId = _.SalesCheckListId,
                SerialNumber = _.SerialNumber
            }).ToList();
        }

        public GetAccountingDocumentDto FindOneById(int id)
        {
            var theAccountingDocument = _dBContext.AccountingDocuments.Find(id);
            return new GetAccountingDocumentDto()
            {
                Id = theAccountingDocument.Id,
                CreationDate = theAccountingDocument.CreationDate,
                SalesCheckListId = theAccountingDocument.SalesCheckListId,
                SerialNumber = theAccountingDocument.SerialNumber
            };
        }
    }
}
