using Microsoft.AspNetCore.Mvc;
using Shop.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/product-categories")]
    public class ProductCategoriesController : Controller
    {
        private ProductCategoryService _service;
        public ProductCategoriesController(ProductCategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        public int Add([Required][FromBody] AddProductCategoryDto dto)
        {
            return _service.Add(dto);
        }
        [HttpGet]
        public List<GetProductCategoryDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetProductCategoryDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
    }
}
