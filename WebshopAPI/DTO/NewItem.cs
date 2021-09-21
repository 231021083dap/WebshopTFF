using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DTO
{
    public class NewItem
    {
        [Required]
        [MinLength(1, ErrorMessage = "Item name can not be blank")]
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        [ForeignKey("SubCategory.SubId")]
        [Required]
        public int SubCategoryId { get; set; }

        public int ItemPrice { get; set; }

        public int ItemDiscount { get; set; }

        public int ItemAmount { get; set; }

        public string ItemStatus { get; set; }
    }
}
