using AutoMapper;
using ProjectDemo.DTOs;
using ProjectDemo.Models;

namespace ProjectDemo.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
