using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Warehouses.Contracts
{
    public interface WarehouseRepository
    {
        int Add(int productCount, int productId);
        void CheckIfProductAmountIsSufficient(int productId);
        Warehouse Find(int id);
        void AddToItemCount(int itemId, int countToAdd);
        List<GetWarehousesGroupedByProductIdDto> GetAll();
        void ManageWarehousesAgain(int countDiffer, int productId);
        void ForAllChecklistItemsManageWarehousesAgain(int id);
        void MinusDeletedAmount(int ProductId, int ProductCount);
    }
}
