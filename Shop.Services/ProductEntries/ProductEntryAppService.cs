using Shop.Entities;
using Shop.Infrastructure.Application;
using Shop.Services.ProductEntries.Contracts;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductEntries
{
    public class ProductEntryAppService : ProductEntryService
    {
        private ProductEntryRepository _productEntryRepository;
        private WarehouseRepository _warehouseRepository;
        private UnitOfWork _unitOfWork;

        public ProductEntryAppService
            (ProductEntryRepository productEntryRepository,
            WarehouseRepository warehouseRepository,
            UnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _productEntryRepository = productEntryRepository;
            _unitOfWork = unitOfWork;
        }


        public int Add(AddProductEntryDto dto)
        {
            var record = _productEntryRepository.Add(dto);
            _warehouseRepository.Add(record.ProductCount, record.ProductId);
            _unitOfWork.Complete();
            _warehouseRepository.CheckIfProductAmountIsSufficient(record.ProductId);
            _unitOfWork.Complete();
            return record.Id;
        }
        public int Update(int id, UpdateProductEntryDto dto)
        {
            var foundedItem = _productEntryRepository.Find(id);

            foundedItem.EntryDate = DateTime.Parse(dto.EntryDate);
            foundedItem.ProductCode = dto.ProductCode;
            foundedItem.EntrySerialNumber = dto.EntrySerialNumber;
            int countDiffer = dto.ProductCount - foundedItem.ProductCount;
            foundedItem.ProductCount = dto.ProductCount;
            _unitOfWork.Complete();
            return countDiffer;
        }
        public void Delete(int id)
        {
            ProductEntry theProductEntry = _productEntryRepository.Find(id);
            _productEntryRepository.Delete(id);
            _warehouseRepository.MinusDeletedAmount(theProductEntry.ProductId, theProductEntry.ProductCount);
            _warehouseRepository.CheckIfProductAmountIsSufficient(theProductEntry.ProductId);
            _unitOfWork.Complete();
        }
        public List<GetProductEntryDto> GetAll()
        {
            return _productEntryRepository.GetAll();
        }
        public GetProductEntryDto FindOneById(int id)
        {
            return _productEntryRepository.FindOneById(id);
        }

    }
}
