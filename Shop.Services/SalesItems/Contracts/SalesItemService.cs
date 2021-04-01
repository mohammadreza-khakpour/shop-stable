using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public interface SalesItemService
    {
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
    }
}
