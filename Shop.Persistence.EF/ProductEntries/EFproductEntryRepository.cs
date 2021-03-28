using Shop.Entities;
using Shop.Services.ProductEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.ProductEntries
{
    public class EFproductEntryRepository : ProductEntryRepository
    {
        private EFDataContext _dBContext;
        public EFproductEntryRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }

        public ProductEntry Add(AddProductEntryDto dto)
        {
            ProductEntry productEntry = new ProductEntry()
            {
                ProductCode = dto.ProductCode,
                EntryDate = DateTime.Parse(dto.EntryDate),
                EntrySerialNumber = dto.EntrySerialNumber,
                ProductCount = dto.ProductCount,
                ProductId = dto.ProductId
            };
            var result = _dBContext.ProductEntries.Add(productEntry);
            return result.Entity;
        }

        public void Delete(int id)
        {
            var res = Find(id);
            _dBContext.ProductEntries.Remove(res);
        }
        public ProductEntry Find(int id)
        {
            return _dBContext.ProductEntries.Find(id);
        }
        public List<GetProductEntryDto> GetAll()
        {
            return _dBContext.ProductEntries.Select(_ => new GetProductEntryDto
            {
                Id = _.Id,
                EntryDate = _.EntryDate,
                EntrySerialNumber = _.EntrySerialNumber,
                ProductCount = _.ProductCount,
                ProductCode = _.ProductCode,
                ProductId = _.ProductId
            }).ToList();
        }

        public GetProductEntryDto FindOneById(int id)
        {
            var theProductEntry = _dBContext.ProductEntries.Find(id);
            return new GetProductEntryDto()
            {
                Id = theProductEntry.Id,
                EntryDate = theProductEntry.EntryDate,
                EntrySerialNumber = theProductEntry.EntrySerialNumber,
                ProductCount = theProductEntry.ProductCount,
                ProductCode = theProductEntry.ProductCode,
                ProductId = theProductEntry.ProductId
            };
        }
    }
}
