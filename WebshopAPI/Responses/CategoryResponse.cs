using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Responses
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<CategorySubResponse> SubCategory { get; set; }
    }

    public class CategorySubResponse
    {
        public int SubId { get; set; }

        public string SubName { get; set; }

    }
}
