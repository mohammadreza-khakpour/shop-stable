using Shop.Entities;
using Shop.Infrastructure.Application;
using Shop.Services.SalesCheckLists.Contracts;
using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists
{
    public class SalesCheckListAppService : SalesCheckListService
    {
        private SalesCheckListRepository _salesCheckListRepository;
        private SalesItemRepository _salesItemRepository;
        private UnitOfWork _unitOfWork;

        public SalesCheckListAppService(SalesCheckListRepository salesCheckListRepository,
            UnitOfWork unitOfWork,
            SalesItemRepository salesItemRepository
            )
        {
            _salesCheckListRepository = salesCheckListRepository;
            _unitOfWork = unitOfWork;
            _salesItemRepository = salesItemRepository;
        }
        public int Add(AddSalesCheckListDto dto)
        {
            SalesCheckList salesCheckList = _salesCheckListRepository.Add(dto);
            List<AddSalesItemDto> dtoSalesItems = dto.SalesItems;
            dtoSalesItems.ForEach(dtoSaleItem =>
            {
                SalesItem SalesItem = _salesItemRepository.Add(dtoSaleItem);
                salesCheckList.Items.Add(SalesItem);
                salesCheckList.OverAllProductCount += dtoSaleItem.ProductCount;
                salesCheckList.OverAllProductPrice += dtoSaleItem.ProductPrice * dtoSaleItem.ProductCount;
            });
            _unitOfWork.Complete();
            return salesCheckList.Id;
        }
        public List<GetSalesCheckListDto> GetAll()
        {
            return _salesCheckListRepository.GetAll();
        }
        public int Update(int id, UpdateSalesCheckListDto dto)
        {
            var salesChecklist = _salesCheckListRepository.FindAndRemoveSalesItems(id);
            _salesItemRepository.DeleteAllItemsByCheckListId(id);
            salesChecklist.RecordDate = DateTime.Parse(dto.RecordDate);
            salesChecklist.SerialNumber = dto.SerialNumber;
            salesChecklist.CustomerFullName = dto.CustomerFullName;
            CheckIfProductsCountAreEnough(dto.SalesItems);
            foreach (var saleitem in dto.SalesItems)
            {
                SalesItem SalesItem = _salesItemRepository.Add(saleitem);
                salesChecklist.Items.Add(SalesItem);
                salesChecklist.OverAllProductCount += SalesItem.ProductCount;
                salesChecklist.OverAllProductPrice += SalesItem.ProductPrice * SalesItem.ProductCount;
            }
            _unitOfWork.Complete();
            return salesChecklist.Id;
        }
        public void Delete(int id)
        {
            _salesCheckListRepository.Delete(id);
            _unitOfWork.Complete();
        }

        public GetOneSalesCheckListDto FindOneById(int id)
        {
            return _salesCheckListRepository.FindOneById(id);
        }

        public void CheckIfProductsCountAreEnough(List<AddSalesItemDto> salesItems)
        {
            foreach (var item in salesItems)
            {
                _salesCheckListRepository.CheckForProductSufficiency(item);
            }
        }

    }
}
