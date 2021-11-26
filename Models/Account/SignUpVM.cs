using System.ComponentModel.DataAnnotations;

namespace SDA_Ecommerce.Models.Account
{
    public class SignUpVM
    {
        [Required]
        public string FName { get; set; }
        [Required]    
        public string LName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password and Confirm Password Aren't Match")]
        public string PasswordConfirmation {  get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Please Enter Your Full Address")]
		public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
    }
}
