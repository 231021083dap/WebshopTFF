using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class SubCategory
    {
        [Key]
        public int SubId { get; set; }

        public string SubName { get; set; }

        [ForeignKey("Category.CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
}
