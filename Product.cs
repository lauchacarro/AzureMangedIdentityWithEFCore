using System.ComponentModel.DataAnnotations.Schema;

namespace MangedIdentityApi
{
    [Table("Product")]
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string? Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
    }
}
