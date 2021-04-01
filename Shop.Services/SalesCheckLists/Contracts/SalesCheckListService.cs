using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public interface SalesCheckListService
    {
        int Add(AddSalesCheckListDto dto);
        void Delete(int id);
        GetOneSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
        int Update(int id, UpdateSalesCheckListDto dto);
        void CheckIfProductsCountAreEnough(List<AddSalesItemDto> salesItems);
    }
}
