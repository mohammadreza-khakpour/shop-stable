using Shop.Entities;
using Shop.Infrastructure.Application;
using Shop.Services.AccountingDocuments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.AccountingDocuments
{
    public class AccountingDocumentAppService : AccountingDocumentService
    {
        private AccountingDocumentRepository _accountingDocumentRepository;
        private UnitOfWork _unitOfWork;
        public AccountingDocumentAppService
            (AccountingDocumentRepository accountingDocumentRepository,
            UnitOfWork unitOfWork)
        {
            _accountingDocumentRepository = accountingDocumentRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddAccountingDocumentDto dto)
        {
            AccountingDocument accountingDoc = new AccountingDocument()
            {
                CreationDate = dto.CreationDate,
                SalesCheckListId = dto.SalesCheckListId,
                SerialNumber = dto.SerialNumber
            };
            var recordId = _accountingDocumentRepository.Add(accountingDoc);
            _unitOfWork.Complete();
            return recordId;
        }
        public void Update(int id, UpdateAccountingDocumentDto dto)
        {
            var foundedItem = _accountingDocumentRepository.Find(id);
            foundedItem.CreationDate = dto.CreationDate;
            foundedItem.SalesCheckListId = dto.SalesCheckListId;
            foundedItem.SerialNumber = dto.SerialNumber;
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _accountingDocumentRepository.Delete(id);
            _unitOfWork.Complete();
        }
        public List<GetAccountingDocumentDto> GetAll()
        {
            return _accountingDocumentRepository.GetAll();
        }
        public GetAccountingDocumentDto FindOneById(int id)
        {
            return _accountingDocumentRepository.FindOneById(id);
        }
    }
}
