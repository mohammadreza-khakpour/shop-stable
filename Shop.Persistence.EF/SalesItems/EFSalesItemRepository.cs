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
        public int Add(SalesItem salesItem)
        {
            return _dbContext.SalesItems.Add(salesItem).Entity.Id;
        }
        public void Delete(int id)
        {
            var res = Find(id);
            _dbContext.SalesItems.Remove(res);
        }
        public List<GetSalesItemDto> GetAll()
        {
            return _dbContext.SalesItems.Select(_ => new GetSalesItemDto
            {
                Id = _.Id,
                ProductCount = _.ProductCount,
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
                ProductId = theSalesItem.ProductId,
                SalesChecklistId = theSalesItem.SalesChecklistId
            };
        }

        public SalesItem Find(int id)
        {
            return _dbContext.SalesItems.Find(id);
        }
    }
}
