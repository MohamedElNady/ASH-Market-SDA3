using SDA_Ecommerce.Models.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDA_Ecommerce.Models.Cart
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }

        public ICollection<CartItem> cartitem { get; set; }
      
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
    }
}
