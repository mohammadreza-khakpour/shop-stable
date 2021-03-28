using Microsoft.AspNetCore.Mvc;
using Shop.Services.ProductEntries.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/product-entries")]
    public class ProductEntriesController : Controller
    {
        private ProductEntryService _service;
        public ProductEntriesController(ProductEntryService service)
        {
            _service = service;
        }
        [HttpPost]
        public int Add([Required][FromBody] AddProductEntryDto dto)
        {
            return _service.Add(dto);
        }
        [HttpGet]
        public List<GetProductEntryDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetProductEntryDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateProductEntryDto dto)
        {
            _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
