using Microsoft.EntityFrameworkCore;
using ProjectDemo.Context.Interfaces;
using ProjectDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDemo.Context.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T:class
    {
        public readonly ProductDbContext _context;
        public EFRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>();
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>();
            _context.Remove(entity);
            Save();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
