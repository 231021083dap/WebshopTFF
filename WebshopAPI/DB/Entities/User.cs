using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("Role.RoleId")]
        public int RoleId { get; set; }

        public Role UserRole { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(8,8, ErrorMessage ="Danish phone-numbers only")]
        public int Phone { get; set; }

        [Required]
        [MinLength(6, ErrorMessage ="Password must be atleast 6 characters")]
        public string Password { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="First name must not be blank")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Last name must not be blank")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [Range(4,4, ErrorMessage ="Danish postal codes only")]
        public int PostalCode { get; set; }

    }
}
