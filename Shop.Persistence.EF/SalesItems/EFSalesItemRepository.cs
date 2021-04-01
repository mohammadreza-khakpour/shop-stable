using Shop.Entities;
using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.SalesItems
{
    public class EFSalesItemRepository : SalesItemRepository
    {
        private EFDataContext _dbContext;
        public EFSalesItemRepository(EFDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SalesItem Add(AddSalesItemDto salesItemDto)
        {
            SalesItem salesItem = new SalesItem()
            {
                ProductCode = salesItemDto.ProductCode,
                ProductCount = salesItemDto.ProductCount,
                ProductPrice = salesItemDto.ProductPrice,
                ProductId = salesItemDto.ProductId
            };
            return salesItem;
        }
        public void DeleteAllItemsByCheckListId(int id)
        {
            _dbContext.SalesItems.Where(saleItem => saleItem.SalesChecklistId == id).ToList().Clear();
        }
        public List<GetSalesItemDto> GetAll()
        {
            return _dbContext.SalesItems.Select(_ => new GetSalesItemDto
            {
                Id = _.Id,
                ProductCount = _.ProductCount,
                ProductCode = _.ProductCode,
                ProductPrice = _.ProductPrice,
                ProductId = _.ProductId,
                SalesChecklistId = _.SalesChecklistId
            }).ToList();
        }
        public GetSalesItemDto FindOneById(int id)
        {
            var theSalesItem = _dbContext.SalesItems.Find(id);
            return new GetSalesItemDto
            {
                Id = theSalesItem.Id,
                ProductCount = theSalesItem.ProductCount,
                ProductCode = theSalesItem.ProductCode,
                ProductPrice = theSalesItem.ProductPrice,
                ProductId = theSalesItem.ProductId,
                SalesChecklistId = theSalesItem.SalesChecklistId
            };
        }

        private SalesItem Find(int id)
        {
            return _dbContext.SalesItems.Find(id);
        }

    }
}
