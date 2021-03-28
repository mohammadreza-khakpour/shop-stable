using Shop.Entities;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.Warehouses
{
    public class EFWarehouseRepository : WarehouseRepository
    {
        private EFDataContext _dbContext;
        public EFWarehouseRepository(EFDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(int productCount, int productId)
        {
            Warehouse wr = new Warehouse
            {
                ProductCount = productCount,
                ProductId = productId
            };
            var result = _dbContext.Warehouses.Add(wr);
            return result.Entity.Id;
        }

        public List<GetWarehousesGroupedByProductIdDto> GetAll()
        {
            return GetWarehousesGroupedByProductId();
        }

        private List<GetWarehousesGroupedByProductIdDto> GetWarehousesGroupedByProductId()
        {
            var res001 = DoInnerJoinQueryOnProductId();
            var res002 = res001.AsEnumerable().GroupBy(_ => _.product_id)
                .Select(group => new GetWarehousesGroupedByProductIdDto
                {
                    product_id = group.Key,
                    product_code = group.First().product_code,
                    product_title = group.First().product_title,
                    product_category_Id = group.First().product_category_Id,
                    productCount_Overall = group.Sum(_ => _.productCount_Overall),
                    product_isEnough = group.First().product_isEnough,
                    product_minimumAmount = group.First().product_minimumAmount

                }).ToList();
            return res002;
        }

        private IQueryable<InnerJoinQueryOnProductId> DoInnerJoinQueryOnProductId()
        {
            var innerJoinQuery =
            from product in _dbContext.Products
            join warehouse in _dbContext.Warehouses on product.Id equals warehouse.ProductId
            select new InnerJoinQueryOnProductId
            {
                product_id = product.Id,
                product_code = product.Code,
                product_title = product.Title,
                product_category_Id = product.ProductCategoryId,
                productCount_Overall = warehouse.ProductCount,
                product_minimumAmount = product.MinimumAmount,
                product_isEnough = product.IsSufficientInStore
            };
            return innerJoinQuery;
        }

        public Warehouse Find(int id)
        {
            return _dbContext.Warehouses.Find(id);
        }

        public void CheckIfProductAmountIsSufficient(int productId)
        {
            Product product = _dbContext.Products.Find(productId);
            List<Warehouse> Warehouses = _dbContext.Warehouses
                .Where(x => x.ProductId == productId).ToList();

            int sum = 0;
            Warehouses.ForEach(warehouse =>
            {
                sum += warehouse.ProductCount;
            });
            if (product.MinimumAmount <= sum)
            {
                product.IsSufficientInStore = true;
            }
            else
            {
                product.IsSufficientInStore = false;
            }
        }

        private Warehouse FindWarehouseWithProperAmount(int AtleastAmount, int productId)
        {
            try
            {
                var result = _dbContext.Warehouses.First(
                _ => _.ProductId == productId && _.ProductCount >= Math.Abs(AtleastAmount));
                return result;
            }
            catch
            {
                Warehouse firstWarehouse = FindTheFirstWarehouse(productId);
                return firstWarehouse;
            }

        }


        private Warehouse FindTheFirstWarehouse(int productId)
        {
            return _dbContext.Warehouses.First(_ => _.ProductId == productId);
        }

        public void ManageWarehousesAgain(int countDiffer, int productId)
        {
            if (countDiffer < 0)
            {
                Warehouse warehouse = FindWarehouseWithProperAmount(countDiffer, productId);
                warehouse.ProductCount += countDiffer;
            }
            if (countDiffer > 0)
            {
                Warehouse warehouse = FindTheFirstWarehouse(productId);
                warehouse.ProductCount += countDiffer;
            }
        }

        public void MinusDeletedAmount(int ProductId, int ProductCount)
        {
            Warehouse warehouse = FindWarehouseWithProperAmount(ProductCount, ProductId);
            warehouse.ProductCount -= ProductCount;
        }

    }
}
