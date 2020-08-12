using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace ShopMarket.Models
{
    public class AccountViewModels
    {
        public class RegisterViewModel
        {
            [Required]
            [MaxLength(300)]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [MaxLength(50)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required]
            [MaxLength(50)]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string RePassword { get; set; }

        }

        
    }
}
