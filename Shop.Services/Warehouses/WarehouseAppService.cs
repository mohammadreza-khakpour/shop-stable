using Shop.Entities;
using Shop.Infrastructure.Application;
using Shop.Services.SalesCheckLists.Contracts;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Warehouses
{
    public class WarehouseAppService : WarehouseService
    {
        private WarehouseRepository _warehouseRepository;
        private SalesCheckListRepository _salesCheckListRepository;
        private UnitOfWork _unitOfWork;
        public WarehouseAppService(WarehouseRepository warehouseRepository,
            UnitOfWork unitOfWork, SalesCheckListRepository salesCheckListRepository)
        {
            _warehouseRepository = warehouseRepository;
            _salesCheckListRepository = salesCheckListRepository;
            _unitOfWork = unitOfWork;
        }

        public void ForAllChecklistItemsManageWarehousesAgain(int id)
        {
            _warehouseRepository.ForAllChecklistItemsManageWarehousesAgain(id);
        }

        public List<GetWarehousesGroupedByProductIdDto> GetAll()
        {
            return _warehouseRepository.GetAll();
        }

        public void ManageWarehousesAgain(int countDiffer, int productId)
        {
            _warehouseRepository.ManageWarehousesAgain(countDiffer, productId);
            _unitOfWork.Complete();
        }

        public void PrepareWarehousesForChecklistUpdate(int checklistId)
        {
            SalesCheckList checklist = _salesCheckListRepository.FindWithItems(checklistId);
            foreach (var item in checklist.Items)
            {
                _warehouseRepository.AddToItemCount(item.ProductId, item.ProductCount);

            }
        }
    }
}
