using System.ComponentModel.DataAnnotations;

namespace SDA_Ecommerce.Models.Product
{
    public class CartItem
    {
        [Key]
        public int cartId { get; set; }

        public ProductDetails productDetails {  get; set; }
        public int Quantity {  get; set; }
	}
}
