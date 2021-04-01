using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Warehouses.Contracts
{
    public interface WarehouseService
    {
        List<GetWarehousesGroupedByProductIdDto> GetAll();
        void ManageWarehousesAgain(int countDiffer, int productId);
        void ForAllChecklistItemsManageWarehousesAgain(int id);
        void PrepareWarehousesForChecklistUpdate(int checklistId);
    }
}
