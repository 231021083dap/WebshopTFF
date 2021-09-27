using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DTO
{
    public class NewLogin
    {
        [Required]        
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be atleast 6 characters")]
        public string Password { get; set; }
    }
}
