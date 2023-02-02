using System;
using DTOs;

namespace Services.Abstracts
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        ProductDTO Create(ProductDTO product);
        void Update(ProductDTO product);
        void Delete(ProductDTO product);
    }


}