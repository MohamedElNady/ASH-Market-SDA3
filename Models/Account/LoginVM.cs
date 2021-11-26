﻿using System.ComponentModel.DataAnnotations;

namespace SDA_Ecommerce.Models.Account
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password {  get; set; }

        public bool RememberMe {  get; set; }   
    }
}