using Microsoft.AspNetCore.Mvc;
using Shop.Services.AccountingDocuments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/accounting-documents")]
    public class AccountingDocumentsController : Controller
    {
        private AccountingDocumentService _service;
        public AccountingDocumentsController(AccountingDocumentService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<GetAccountingDocumentDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetAccountingDocumentDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
    }
}
