using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserRoleResponse UserRole { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }

    public class UserRoleResponse
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }

}
