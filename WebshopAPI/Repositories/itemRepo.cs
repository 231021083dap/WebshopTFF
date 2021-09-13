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

    public class itemRepo : IItemRepo
    {
        private readonly WebshopContext _context;

        public itemRepo(WebshopContext context)
        {
            _context = context;
        }
    }


}
