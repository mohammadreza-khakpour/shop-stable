using Microsoft.AspNetCore.Mvc;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehousesController : Controller
    {
        private WarehouseService _service;
        public WarehousesController(WarehouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<GetWarehousesGroupedByProductIdDto> GetAll()
        {
            return _service.GetAll();
        }
    }
}
