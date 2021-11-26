using System.ComponentModel.DataAnnotations;

namespace Ecommerce_SDA.Models.Product
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName {  get; set; }
        public string CreatedDate {  get; set; }
    }
}
