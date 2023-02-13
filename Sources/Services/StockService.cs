using System;
using AutoMapper;
using DTOs;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductService> _logger;

        public StockService(ILogger<ProductService> logger, IUnitOfWork unitOfWork, IStockRepository stockRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _stockRepository = stockRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public void Create(StockDTO stock)
        {
            _logger.LogInformation("Started creating a new stock.");
            _stockRepository.Create(MyMapper.DtoToStock(stock));
            _unitOfWork.SaveChanges();
            _logger.LogInformation("Successfully created a new stock.");
        }

        public void Delete(StockDTO stock)
        {
            _logger.LogInformation("Started deleting a stock.");
            _stockRepository.Delete(MyMapper.DtoToStock(stock));
            _unitOfWork.SaveChanges();
            _logger.LogInformation("Successfully deleted a stock.");
        }

        public IEnumerable<StockDTO> GetAll()
        {
            _logger.LogInformation("Started retrieving all stocks.");
            var list = new List<StockDTO>();

            foreach (var s in _stockRepository.GetAll())
            {
                list.Add(MyMapper.StockToDTO(s));
            }
            _logger.LogInformation("Successfully retrieved all stocks.");
            return list;
        }

        public StockDTO GetById(int id)
        {
            _logger.LogInformation("Started retrieving a stock by id.");
            var stck = _stockRepository.GetById(id);
            _logger.LogInformation("Successfully retrieved a stock by id.");
            return MyMapper.StockToDTO(stck);
        }

        public void Update(StockDTO stock)
        {
            _logger.LogInformation("Started updating a stock.");
            _stockRepository.Update(MyMapper.DtoToStock(stock));
            _unitOfWork.SaveChanges();
            _logger.LogInformation("Successfully updated a stock.");
        }

    }
}

