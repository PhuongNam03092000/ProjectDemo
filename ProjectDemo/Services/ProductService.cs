using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProjectDemo.Context.Interfaces;
using ProjectDemo.DTOs;
using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _rep;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductService(IProductRepository rep, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _rep = rep;
            _mapper = mapper;
        }
        public ActionStatus Add(ProductDTO productDTO)
        {
            this.UploadFile(ref productDTO);
            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            return _rep.Add(product);
        }

        public ActionStatus Delete(int Id)
        {
            var product = _rep.GetById(Id);
            return _rep.Delete(product);
        }

        public List<ProductDTO> GetAll()
        {
            var productList = _rep.GetAll();
            return _mapper.Map<List<Product>, List<ProductDTO>>(productList);
        }

        public ProductDTO GetById(int Id)
        {
            return _mapper.Map<Product, ProductDTO>(_rep.GetById(Id));
        }

        public ActionStatus Update(ProductDTO productDTO)
        {
            var oldProduct = this.GetById(productDTO.Id);
            var shouldUpateName = String.IsNullOrWhiteSpace(productDTO.Name)
                && oldProduct.Name.CompareTo(productDTO.Name) != 0;
            var shouldUpateDescription = String.IsNullOrWhiteSpace(productDTO.Description)
                && oldProduct.Description.CompareTo(productDTO.Description) != 0;
            var shouldUpateImage = productDTO.FileImage != null;

            if (shouldUpateName || shouldUpateDescription || shouldUpateImage)
            {
                if(shouldUpateImage)
                    UploadFile(ref productDTO);
                var product = _mapper.Map<ProductDTO, Product>(productDTO);
                return _rep.Update(product);
            }

            return ActionStatus.Fail;
        }

        public void UploadFile(ref ProductDTO productDTO)
        {
            var path = "image/";
            Console.WriteLine(productDTO.FileImage.ContentType);
            if (productDTO.FileImage != null)
            {
                string fileEx = "jpg";
                if (productDTO.FileImage.ContentType == "image/png") { fileEx = "png"; }
                else if (productDTO.FileImage.ContentType == "image/gif") { fileEx = "gif"; }
                else if (productDTO.FileImage.ContentType == "image/jpeg") { fileEx = "jpeg"; }

                path += String.Format("{0}.{1}", Guid.NewGuid().ToString(), fileEx);
                productDTO.ImagePath = path;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, path);
                using (Stream fileStream = new FileStream(serverFolder, FileMode.Create))
                {
                    productDTO.FileImage.CopyTo(fileStream);
                }
            }
            Console.WriteLine("File path in Upload Image: " + path);
        }
    }
}
