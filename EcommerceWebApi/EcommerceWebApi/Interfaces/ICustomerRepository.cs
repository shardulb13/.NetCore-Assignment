using EcommerceWebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApi.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> getAll();
        Task<Customers> getById(int id);
        Task<Customers> AddCustomer(Customers customerObj);
        Task<Customers> UpdateCustomer(Customers customerObj, int id);
        Task<Customers> DeleteCustomer(int id);
    }
}
