using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }

        [ForeignKey("Orders.OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("Item.ItemId")]
        public int ItemId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int CurrentPrice { get; set; }

        



    }
}
