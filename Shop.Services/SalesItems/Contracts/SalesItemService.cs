using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public interface SalesItemService
    {
        int Add(AddSalesItemDto dto);
        void Delete(int id);
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
        void Update(int id, UpdateSalesItemDto dto);
    }
}
