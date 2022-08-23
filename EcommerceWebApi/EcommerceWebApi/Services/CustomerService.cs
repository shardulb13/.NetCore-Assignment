using EcommerceWebApi.Data;
using EcommerceWebApi.Interfaces;
using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApi.Services
{
    public class CustomerService : ICustomerRepository
    {
        private readonly EcommerceDbContext ecommerceDbContext;
        public CustomerService(EcommerceDbContext ecommerceDbContext)
        {
            this.ecommerceDbContext = ecommerceDbContext;
        }
        public async Task<Customers> AddCustomer(Customers customerObj)
        {
            var result = await ecommerceDbContext.CustomerTable.AddAsync(customerObj);
            ecommerceDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<Customers> DeleteCustomer(int id)
        {
            var result = await ecommerceDbContext.CustomerTable.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                ecommerceDbContext.CustomerTable.Remove(result);
                ecommerceDbContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Customers> getAll()
        {
            return ecommerceDbContext.CustomerTable.ToList();
        }

        public async Task<Customers> getById(int id)
        {
            var result = await ecommerceDbContext.CustomerTable.FirstOrDefaultAsync(i => i.Id == id);
            return result;
        }

        public async Task<Customers> UpdateCustomer(Customers customerObj, int id)
        {
            var result = await ecommerceDbContext.CustomerTable.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.FirstName = customerObj.FirstName;
                result.LastName = customerObj.LastName;
                result.Email = customerObj.Email;
                ecommerceDbContext.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
