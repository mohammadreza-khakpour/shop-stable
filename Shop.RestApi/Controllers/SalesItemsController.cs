using Microsoft.AspNetCore.Mvc;
using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/sales-items")]
    public class SalesItemsController : Controller
    {
        private SalesItemService _service;
        public SalesItemsController(SalesItemService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<GetSalesItemDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetSalesItemDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
    }
}
