using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemo.Context.Interfaces
{
    public interface IEFRepository<T> where T : class
    {
        ActionStatus Add(T entity);
        ActionStatus Delete(T entity);
        ActionStatus Update(T entity);
        List<T> GetAll();
        T GetById(int Id);
    }
}
