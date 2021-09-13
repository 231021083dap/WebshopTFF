using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DTO
{
    public class UpdateSubCategory
    {
        public string SubName { get; set; }

        [ForeignKey("Category.CategoryId")]
        public int CategoryId { get; set; }
    }
}
