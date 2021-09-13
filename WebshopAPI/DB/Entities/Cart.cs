using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("User.UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string Items { get; set; }



    }
}
