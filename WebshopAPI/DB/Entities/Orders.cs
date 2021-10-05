using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User.UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        // public DateTime OrderDate { get; set; } = DateTime.Now;

        public string OrderStatus { get; set; }

    }
}
