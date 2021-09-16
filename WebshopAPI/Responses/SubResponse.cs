using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Responses
{
    public class SubResponse
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public int CatId { get; set; }

        public SubCatResponse Category { get; set; }

    }

    public class SubCatResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
