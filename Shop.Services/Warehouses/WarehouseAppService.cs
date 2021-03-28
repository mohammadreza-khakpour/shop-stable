using Shop.Infrastructure.Application;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Warehouses
{
    public class WarehouseAppService : WarehouseService
    {
        private WarehouseRepository _warehouseRepository;
        private UnitOfWork _unitOfWork;
        public WarehouseAppService(WarehouseRepository warehouseRepository, UnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }
        public List<GetWarehousesGroupedByProductIdDto> GetAll()
        {
            return _warehouseRepository.GetAll();
        }
    }
}
