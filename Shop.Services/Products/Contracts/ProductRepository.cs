using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void CheckForDuplicatedTitle(string title);
        void CheckForDuplicatedCode(string code);
        Product Add(AddProductDto dto);
        void Delete(int id);
        Product Find(int id);
        GetProductDto FindOneById(int id);
        List<GetProductDto> GetAll();
        void UpdateSufficiencyStatus(int productId);
    }
}
