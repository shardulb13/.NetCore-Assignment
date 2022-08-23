using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options): base(options)
        {

        }

        public DbSet<Customers> CustomerTable { get; set; }
        public DbSet<Products> ProductsTable { get; set; }
    }
}
