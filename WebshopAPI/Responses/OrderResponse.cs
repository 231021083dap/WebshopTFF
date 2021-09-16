using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public OrderUserResponse OrderUser { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }

    public class OrderUserResponse
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
    }
}
