using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Model
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
        public string ProductName { get; set; }
        public int price { get; set; }
    }
}
