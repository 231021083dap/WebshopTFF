using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Item name can not be blank")]
        public string ItemName { get; set; }

        [ForeignKey("{SubCategory.SubId}")]
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        public int ItemPrice { get; set; }   

        public int ItemDiscount { get; set; }
        
        public int ItemAmount { get; set; }

        public string ItemStatus { get; set; } = "In Stock";
    }
}
