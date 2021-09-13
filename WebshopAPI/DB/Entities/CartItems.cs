using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class CartItems
    {
        [Key]
        public int CartItemId { get; set; }

        [ForeignKey("Cart.CartId")]
        public int CartId { get; set; }

        [ForeignKey("Item.ItemId")]
        public int ItemId { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }



    }
}
