using Shop.Infrastructure.Application;
using Shop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Products
{
    public class ProductAppService : ProductService
    {
        private ProductRepository _productRepository;
        private UnitOfWork _unitOfWork;
        public ProductAppService(ProductRepository productRepository, UnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public int Add(AddProductDto dto)
        {
            CheckForDuplicatedCode(dto.Code);
            CheckForDuplicatedTitle(dto.Title);
            var record = _productRepository.Add(dto);
            _unitOfWork.Complete();
            return record.Id;
        }

        private void CheckForDuplicatedTitle(string title)
        {
            _productRepository.CheckForDuplicatedTitle(title);
        }
        private void CheckForDuplicatedCode(string code)
        {
            _productRepository.CheckForDuplicatedCode(code);
        }

        public void UpdateSufficiencyStatus(int productId)
        {
            _productRepository.UpdateSufficiencyStatus(productId);
            _unitOfWork.Complete();
        }

        public List<GetProductDto> GetAll()
        {
            return _productRepository.GetAll();
        }

        public GetProductDto FindOneById(int id)
        {
            return _productRepository.FindOneById(id);
        }

        public void Update(int id, UpdateProductDto dto)
        {
            var res = _productRepository.Find(id);
            res.Code = dto.Code;
            res.MinimumAmount = dto.MinimumAmount;
            res.ProductCategoryId = dto.ProductCategoryId;
            res.Title = dto.Title;
            res.IsSufficientInStore = dto.IsSufficientInStore;
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _unitOfWork.Complete();
        }

    }
}
