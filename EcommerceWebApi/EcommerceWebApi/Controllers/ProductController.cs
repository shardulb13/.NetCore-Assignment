using EcommerceWebApi.Interfaces;
using EcommerceWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository; 
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(productRepository.getAll());
        }

        [HttpPost]
        public IActionResult AddProducts(Products productsObj)
        {
            return Ok(productRepository.AddProducts(productsObj));
        }

        [HttpPut]
        public async Task<Products> UpdateProducts(Products productsObj, int id)
        {
            return await productRepository.UpdateProducts(productsObj, id);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(productRepository.getById(id));
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(productRepository.DeleteProducts(id));
        }
    }
}
