using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public interface SalesCheckListService
    {
        int Add(AddSalesCheckListDto dto);
        void Delete(int id);
        GetSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
        void Update(int id, UpdateSalesCheckListDto dto);
    }
}
