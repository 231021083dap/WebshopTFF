using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DTO
{
    public class UpdateItem
    {
        [Required]
        [MinLength(1, ErrorMessage = "Item name can not be blank")]
        public string ItemName { get; set; }

        [ForeignKey("Subcategory.SubId")]
        [Required]
        public string ItemSubCategory { get; set; }

        public int ItemPrice { get; set; }

        public Boolean ItemOnSale { get; set; } = false;

        public int DiscountPercent { get; set; }

        public Boolean ItemInstock { get; set; }

        public int AmountInStorage { get; set; }
    }
}
