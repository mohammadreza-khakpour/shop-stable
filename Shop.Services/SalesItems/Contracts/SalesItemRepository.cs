using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems.Contracts
{
    public interface SalesItemRepository
    {
        SalesItem Add(AddSalesItemDto salesItemDto);
        void DeleteAllItemsByCheckListId(int id);
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
    }
}
