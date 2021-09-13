using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DB.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemSubCategory { get; set; }
        public int ItemPrice { get; set; }
        public  Boolean ItemOnSale { get; set; }

    }
}
