using Ecommerce_SDA.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace SDA_Ecommerce.Models
{
    public class ProductDetails
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string Name {  get; set; }

        [Required]
        [Display(Name = "Product Brand")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description {  get; set; }
        [Required]
        [Display(Name = "Price")]
        public string Price {  get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public string CreatedDate {  get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category {  get; set; }
        //we will add this in next version due to deadline (adding categories like laptops and mobiles with imgs and implement them dynamicly in the home page!"
        //public Category Category {  get; set; }

    }
}
