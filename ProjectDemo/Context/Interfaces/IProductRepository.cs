using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemo.Context.Interfaces
{
    public interface IProductRepository : IEFRepository<Product>
    {
    }
}
