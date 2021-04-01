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
        public SalesItemAppService(SalesItemRepository salesItemRepository)
        {
            _salesItemRepository = salesItemRepository;
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
