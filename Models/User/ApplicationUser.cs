using Ecommerce_SDA.Models.Cards;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Ecommerce_SDA.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public ICollection<VisaCards> VisaCards { get; set; }

    }

}
