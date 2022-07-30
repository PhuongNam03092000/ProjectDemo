using AutoMapper;
using ProjectDemo.Context.Interfaces;
using ProjectDemo.DTOs;
using ProjectDemo.Models;
using System;
using System.Collections.Generic;

namespace ProjectDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _rep;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository rep,IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }
        public void Add(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            _rep.Add(product);
        }

        public void Delete(int Id)
        {
            var product = _rep.GetById(Id);
            _rep.Delete(product);
        }

        public List<ProductDTO> GetAll()
        {
            var productList = _rep.GetAll();
            return _mapper.Map<List<Product>,List<ProductDTO>>(productList);
        }

        public ProductDTO GetById(int Id)
        {
            return _mapper.Map<Product, ProductDTO>(_rep.GetById(Id));
        }

        public void Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            _rep.Update(product);
        }
    }
}
