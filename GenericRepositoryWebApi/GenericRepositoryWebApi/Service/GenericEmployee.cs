using GenericRepositoryWebApi.Data;
using GenericRepositoryWebApi.Interface;
using GenericRepositoryWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryWebApi.Service
{
    public class GenericEmployee<T> : IGenericEmployee<T> where T : class
    {
        private ApplicationDbContext _context;
        private DbSet<T> table;

        public GenericEmployee(ApplicationDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetbyId(object Id)
        {
            return table.Find(Id);
        }

        public async Task<T> AddEmp(T obj)
        {
            var store = await table.AddAsync(obj);
            _context.SaveChanges();
            return store.Entity;
        }
        public void UpdateEmp(T obj)
        {
            table.Update(obj);
            _context.SaveChanges();
        }

        public T DeleteEmp(T obj)
        {
            var DataDelete = table.Remove(obj);
            _context.SaveChanges();
            return DataDelete.Entity;
        }


    }
}
