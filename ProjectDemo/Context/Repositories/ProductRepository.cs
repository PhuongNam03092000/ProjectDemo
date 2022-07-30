using ProjectDemo.Context.Interfaces;
using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemo.Context.Repositories
{
    public class ProductRepository : EFRepository<Product>,IProductRepository
    {
        public ProductRepository(ProductDbContext context):base(context)
        {

        }
    }
}
