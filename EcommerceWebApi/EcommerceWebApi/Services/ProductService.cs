using EcommerceWebApi.Data;
using EcommerceWebApi.Interfaces;
using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApi.Services
{
    public class ProductService : IProductRepository
    {
        private readonly EcommerceDbContext ecommerceDbContext;
        public ProductService(EcommerceDbContext ecommerceDbContext)
        {
            this.ecommerceDbContext = ecommerceDbContext;
        }
        public async Task<Products> AddProducts(Products productObj)
        {
            var result = await ecommerceDbContext.ProductsTable.AddAsync(productObj);
            ecommerceDbContext.SaveChanges();
            return result.Entity;
        }

        public Products DeleteProducts(int id)
        {
            var result = ecommerceDbContext.ProductsTable.Where(o => o.productId == id).FirstOrDefault();
            if (result != null)
            {
                ecommerceDbContext.ProductsTable.Remove(result);
                ecommerceDbContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Products> getAll()
        {
            return ecommerceDbContext.ProductsTable.ToList();
        }

        public Products getById(int id)
        {
            return ecommerceDbContext.ProductsTable.Find(id);
        }

        public async Task<Products> UpdateProducts(Products productObj, int id)
        {
            var result = await ecommerceDbContext.ProductsTable.Where(o => o.productId == id).FirstOrDefaultAsync();
            if (result.productId == id)
            {
                result.ProductName = productObj.ProductName;
                result.price = productObj.price;
                ecommerceDbContext.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
