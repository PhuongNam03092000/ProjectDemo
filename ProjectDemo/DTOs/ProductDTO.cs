using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [MaxLength(5)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile FileImage { get; set; }
    }
}
