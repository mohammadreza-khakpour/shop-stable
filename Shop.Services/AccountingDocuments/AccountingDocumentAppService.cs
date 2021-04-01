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
        public void Add(int checklistId)
        {
            _accountingDocumentRepository.Add(checklistId);
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
