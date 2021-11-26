using Ecommerce_SDA.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_SDA.Models.Cards
{
    public class VisaCards
    {
        [Key]
        public int VisaId { get; set; }

        public string VisaNumber {  get; set; }
        public string VisaMonthEnd { get; set; }
        public string VisaYearEnd{ get; set; }
        public string VisaCVC {  get; set;}
        public string VisaHolderName { get; set; }

        public ApplicationUser User {  get; set;}
    }
}
