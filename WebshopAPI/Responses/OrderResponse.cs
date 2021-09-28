using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Helpers;

namespace WebshopAPI.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public OrderUserResponse User { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }

    public class OrderUserResponse
    {
        public int UserId { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
