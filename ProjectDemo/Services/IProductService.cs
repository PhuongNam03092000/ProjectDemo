using ProjectDemo.DTOs;
using ProjectDemo.Models;
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
        ActionStatus Add(ProductDTO productDTO);
        ActionStatus Delete(int Id);
        ActionStatus Update(ProductDTO productDTO);
        void UploadFile(ref ProductDTO productDTO);
    }
}
