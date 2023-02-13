using System;
using AutoMapper;
using DTOs;
using Microsoft.Extensions.Logging;
using Models;
using Repository;
using Services.Abstracts;
using Services.UnitOfWork;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger, IUnitOfWork unitOfWork, IProductRepository productRepository,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            _logger.LogInformation("Getting all products");
            var list = new List<ProductDTO>();
            foreach (var item in _productRepository.GetAll())
                list.Add(_mapper.Map<ProductDTO>(item));

            return list;
        }

        public ProductDTO GetById(int id)
        {
            _logger.LogInformation($"Getting product with id: {id}");
            var data = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(data);
        }

        public ProductDTO Create(ProductDTO product)
        {
            _logger.LogInformation($"Creating product with name: {product.Name}");
            _productRepository.Create(_mapper.Map<Product>(product));
            _unitOfWork.SaveChanges();

            return product;
        }

        public void Update(ProductDTO product)
        {
            _logger.LogInformation($"Updating product with id: {product.Id}");
            var produ = _productRepository.GetById(product.Id);
            produ.Name = product.Name;
            produ.Price = product.Price;
            produ.Quantity = product.Quantity;

            _productRepository.Update(produ);
            _unitOfWork.SaveChanges();
        }

        public void Delete(ProductDTO product)
        {
            _logger.LogInformation($"Deleting product with id: {product.Id}");
            _productRepository.Delete(_mapper.Map<Product>(product));
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<ProductDTO> GetByName(string name)
        {
            _logger.LogInformation($"Getting products with name: {name}");
            var list = new List<ProductDTO>();
            foreach (var item in _productRepository.GetByName(name))
                list.Add(_mapper.Map<ProductDTO>(item));
            return list;
        }

    }
}

