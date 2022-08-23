using EcommerceWebApi.Interfaces;
using EcommerceWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(customerRepository.getAll());
        }

        [HttpPost]
        public Task<Customers> AddCustomers(Customers customersObj)
        {
            return customerRepository.AddCustomer(customersObj);
        }

        [HttpPut]
        public Task<Customers> UpdateCustomer(Customers customersObj, int id)
        {
            return customerRepository.UpdateCustomer(customersObj, id);
        }

        [HttpDelete]
        public Task<Customers> DeleteCustomer(int id)
        {
            return customerRepository.DeleteCustomer(id);
        }

        [HttpGet("{id}")]
        public Task<Customers> GetById(int id)
        {
            return customerRepository.getById(id);
        }
    }
}
