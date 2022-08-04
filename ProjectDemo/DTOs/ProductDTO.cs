using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile FileImage { get; set; }
    }
}
