using Shop.Entities;
using Shop.Infrastructure.Application;
using Shop.Services.SalesCheckLists.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists
{
    public class SalesCheckListAppService : SalesCheckListService
    {
        private SalesCheckListRepository _salesCheckListRepository;
        private UnitOfWork _unitOfWork;
        public SalesCheckListAppService
            (SalesCheckListRepository salesCheckListRepository, UnitOfWork unitOfWork)
        {
            _salesCheckListRepository = salesCheckListRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddSalesCheckListDto dto)
        {
            SalesCheckList salesCheckList = new SalesCheckList
            {
                RecordDate = dto.RecordDate,
                SerialNumber = dto.SerialNumber
            };
            var recordId = _salesCheckListRepository.Add(salesCheckList);
            _unitOfWork.Complete();
            return recordId;
        }
        public void Update(int id, UpdateSalesCheckListDto dto)
        {
            var res = _salesCheckListRepository.Find(id);
            res.RecordDate = dto.RecordDate;
            res.SerialNumber = dto.SerialNumber;
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _salesCheckListRepository.Delete(id);
        }
        public List<GetSalesCheckListDto> GetAll()
        {
            return _salesCheckListRepository.GetAll();
        }
        public GetSalesCheckListDto FindOneById(int id)
        {
            return _salesCheckListRepository.FindOneById(id);
        }

    }
}
