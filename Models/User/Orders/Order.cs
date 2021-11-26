using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_SDA.Models.User.Orders
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int InvoiceNumber {  get; set; }
        public int ProductId {  get; set; }
        public string CreatedDate {  get; set; }
        public string DeliveryDate { get; set; }
        public string CustomerId {  get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser User {  get; set; }
    }
}
