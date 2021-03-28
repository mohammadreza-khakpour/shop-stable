using Shop.Entities;
using Shop.Infrastructure.Application;
using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesItems
{
    public class SalesItemAppService : SalesItemService
    {
        private SalesItemRepository _salesItemRepository;
        private UnitOfWork _unitOfWork;
        public SalesItemAppService(SalesItemRepository salesItemRepository, UnitOfWork unitOfWork)
        {
            _salesItemRepository = salesItemRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddSalesItemDto dto)
        {
            SalesItem salesItem = new SalesItem
            {
                ProductCount = dto.ProductCount,
                ProductId = dto.ProductId,
                SalesChecklistId = dto.SalesChecklistId
            };
            var recordId = _salesItemRepository.Add(salesItem);
            _unitOfWork.Complete();
            return recordId;
        }
        public void Update(int id, UpdateSalesItemDto dto)
        {
            var res = _salesItemRepository.Find(id);
            res.ProductCount = dto.ProductCount;
            res.ProductId = dto.ProductId;
            res.SalesChecklistId = dto.SalesChecklistId;
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _salesItemRepository.Delete(id);
        }
        public List<GetSalesItemDto> GetAll()
        {
            return _salesItemRepository.GetAll();
        }
        public GetSalesItemDto FindOneById(int id)
        {
            return _salesItemRepository.FindOneById(id);
        }
    }
}
