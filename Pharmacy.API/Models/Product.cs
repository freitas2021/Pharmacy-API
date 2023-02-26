using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }  
    }
}
