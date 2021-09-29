using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Helpers;

namespace WebshopAPI.DTO
{
    public class NewUser
    {

        public Role Role { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Invalid Phone length")]
        [MaxLength(24, ErrorMessage = "Unexpected Phone length")]
        public string Phone { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be atleast 6 characters")]
        public string Password { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "First name must not be blank")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Last name must not be blank")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [MinLength(3, ErrorMessage = "Unexpected Postal Code length")]
        [MaxLength(4, ErrorMessage = "Unexpected Postal Code length")]
        public string PostalCode { get; set; }


    }
}
