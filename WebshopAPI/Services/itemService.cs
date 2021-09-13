using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Repositories;

namespace WebshopAPI.Services
{
    public interface IItemService
    {

    }

    public class itemService : IItemService
    {
        private readonly IItemRepo _itemRepo;

        public itemService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }
    }
}
