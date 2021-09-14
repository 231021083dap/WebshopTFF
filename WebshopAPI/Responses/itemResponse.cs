using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Responses
{
    public class ItemResponse
    {       
        public int ItemId { get; set; }

        public string ItemName { get; set; }
   
        public string ItemSubCategory { get; set; }

        public int ItemPrice { get; set; }

        public int ItemDiscount { get; set; }

        public int ItemAmount { get; set; }
    }
}
