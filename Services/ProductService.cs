using System;
using AutoMapper;
using DTOs;
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
             
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var list = new List<ProductDTO>();
            foreach (var item in _productRepository.GetAll())
                list.Add(_mapper.Map<ProductDTO>(item));
            return list;
        }

        public ProductDTO GetById(int id)
        {

            var data = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(data);
        }

        public void Create(ProductDTO product)
        {
            _productRepository.Create(_mapper.Map<Product>(product));
            _unitOfWork.SaveChanges();
        }

        public void Update(ProductDTO product)
        {

            _productRepository.Update(_mapper.Map<Product>(product));
            _unitOfWork.SaveChanges();
        }

        public void Delete(ProductDTO product)
        {
            _productRepository.Delete(_mapper.Map<Product>(product));
            _unitOfWork.SaveChanges();
        }
    }
}

