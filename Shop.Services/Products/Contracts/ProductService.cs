using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Products.Contracts
{
    public interface ProductService
    {
        int Add(AddProductDto dto);
        void Delete(int id);
        GetProductDto FindOneById(int id);
        List<GetProductDto> GetAll();
        void Update(int id, UpdateProductDto dto);
        void UpdateSufficiencyStatus(int productId);
    }
}
