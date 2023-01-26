using System;
using AutoMapper;
using DTOs;
using Models;
using MONAPI.Mapper;
using Repository;
using Services.Abstracts;
using Services.UnitOfWork;

namespace Services
{
	public class StockService : IStockService
	{
		 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IUnitOfWork unitOfWork, IStockRepository stockRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public void Create(StockDTO stock)
        {
           
            _stockRepository.Create(MyMapper.DtoToStock(stock));
            _unitOfWork.SaveChanges();
        }

        public void Delete(StockDTO stock)
        {
            _stockRepository.Delete(MyMapper.DtoToStock(stock));
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<StockDTO> GetAll()
        {
            var list = new List<StockDTO>();
 
           
            foreach (var s in _stockRepository.GetAll())
            {
                 
                list.Add(MyMapper.StockToDTO(s));
            }
            return list;
        }

        

        public StockDTO GetById(int id)
        {
         var  stck=  _stockRepository.GetById(id);
           
            return MyMapper.StockToDTO(stck);
        }

        public void Update(StockDTO stock)
        {
            _stockRepository.Update(MyMapper.DtoToStock(stock));
            _unitOfWork.SaveChanges();
        }
    }
}

