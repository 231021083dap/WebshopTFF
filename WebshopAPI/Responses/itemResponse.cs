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
        public string ItemDescription { get; set; }
        public int SubCategoryId { get; set; }
        public ItemSubResponse SubCategory { get; set; }
        public int ItemPrice { get; set; }
        public int ItemDiscount { get; set; }
        public int ItemAmount { get; set; }
        public string ItemStatus { get; set; }
    }

    public class ItemSubResponse
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public int CategoryId { get; set; }
    }
}
