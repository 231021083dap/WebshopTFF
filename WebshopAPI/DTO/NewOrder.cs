using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DTO
{
    public class NewOrder
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User.UserId")]
        public int UserId { get; set; }

      //  public static DateTime OrderDate { get; set; } = DateTime.Now;

        public string OrderStatus { get; set; }
    }
}
