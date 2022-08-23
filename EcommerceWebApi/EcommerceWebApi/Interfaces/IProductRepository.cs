using EcommerceWebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceWebApi.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Products> getAll();
        Products getById(int id);
        Task<Products> AddProducts(Products productObj);
        Task<Products> UpdateProducts(Products productObj, int id);
        Products DeleteProducts(int id);

    }
}
