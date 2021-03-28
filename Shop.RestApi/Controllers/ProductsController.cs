using Microsoft.AspNetCore.Mvc;
using Shop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public int Add([Required][FromBody] AddProductDto dto)
        {
            return _service.Add(dto);
        }
        [HttpGet]
        public List<GetProductDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetProductDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateProductDto dto)
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
