using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB;

namespace WebshopAPI.Repositories
{
    public interface IItemRepo
    {

    }

    public class ItemRepo : IItemRepo
    {
        private readonly WebshopContext _context;

        public ItemRepo(WebshopContext context)
        {
            _context = context;
        }
    }


}
