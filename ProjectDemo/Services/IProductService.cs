using ProjectDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemo.Services
{
    public interface IProductService
    {
        List<ProductDTO> GetAll();
        ProductDTO GetById(int Id);
        void Add(ProductDTO productDTO);
        void Delete(int Id);
        void Update(ProductDTO productDTO);
    }
}
