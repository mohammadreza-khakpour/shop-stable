using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductEntries.Contracts
{
    public interface ProductEntryService
    {
        int Add(AddProductEntryDto dto);
        void Delete(int id);
        GetProductEntryDto FindOneById(int id);
        List<GetProductEntryDto> GetAll();
        void Update(int id, UpdateProductEntryDto dto);
    }
}
