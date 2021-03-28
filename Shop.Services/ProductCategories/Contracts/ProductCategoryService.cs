using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryService
    {
        int Add(AddProductCategoryDto dto);
        GetProductCategoryDto FindOneById(int id);
        List<GetProductCategoryDto> GetAll();
    }
}
