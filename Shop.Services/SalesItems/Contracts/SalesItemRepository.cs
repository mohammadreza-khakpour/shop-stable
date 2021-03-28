using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public interface SalesItemRepository
    {
        int Add(SalesItem salesItem);
        void Delete(int id);
        SalesItem Find(int id);
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
    }
}
