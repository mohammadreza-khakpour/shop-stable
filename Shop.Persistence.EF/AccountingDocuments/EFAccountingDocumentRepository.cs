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

        public void Add(int checklistId)
        {
            SalesCheckList theCheckList = _dBContext.SalesCheckLists.Find(checklistId);
            string randomSerialNumber = MakeRandomString(9);
            AccountingDocument accountingDocument = new AccountingDocument()
            {
                CreationDate = theCheckList.RecordDate,
                SalesCheckListId = theCheckList.Id,
                SerialNumber = randomSerialNumber,
                SalesCheckListOverallPrice = theCheckList.OverAllProductPrice,
                SalesCheckListSerialNumber = theCheckList.SerialNumber
            };
            _dBContext.AccountingDocuments.Add(accountingDocument);
        }
        private string MakeRandomString(int size, bool lowerCase = false)
        {
            //DateTime rightNow = new DateTime();
            DateTime rightNow = DateTime.Now;
            Random _random = new Random();
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() + rightNow.ToLongTimeString() :
                builder.ToString() + rightNow.ToLongTimeString();
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
                SerialNumber = _.SerialNumber,
                SalesCheckListOverallPrice = _.SalesCheckListOverallPrice,
                SalesCheckListSerialNumber = _.SalesCheckListSerialNumber
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
                SerialNumber = theAccountingDocument.SerialNumber,
                SalesCheckListOverallPrice = theAccountingDocument.SalesCheckListOverallPrice,
                SalesCheckListSerialNumber = theAccountingDocument.SalesCheckListSerialNumber
            };
        }
    }
}
