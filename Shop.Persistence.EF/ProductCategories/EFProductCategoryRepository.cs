using Shop.Entities;
using Shop.Services.ProductCategories.Contracts;
using Shop.Services.ProductCategories.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCategoryRepository
    {
        private EFDataContext _dBContext;
        public EFProductCategoryRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void CheckForDuplicatedTitle(string title)
        {
            bool result = _dBContext.ProductCategories
                .Any(productCategory => productCategory.Title == title);
            if (result == true)
            {
                throw new ProductCategoryDuplicatedTitleException();
            }
        }
        public ProductCategory Add(AddProductCategoryDto dto)
        {
            var res = _dBContext.ProductCategories.Add(new ProductCategory
            {
                Title = dto.Title
            });
            return res.Entity;
        }
        public List<GetProductCategoryDto> GetAll()
        {
            return _dBContext.ProductCategories.Select(_ => new GetProductCategoryDto
            {
                Id = _.Id,
                Title = _.Title
            }).ToList();
        }

        public GetProductCategoryDto FindOneById(int id)
        {
            var theProductCategory = _dBContext.ProductCategories.Find(id);
            return new GetProductCategoryDto() { Id = theProductCategory.Id, Title = theProductCategory.Title };
        }
    }
}
