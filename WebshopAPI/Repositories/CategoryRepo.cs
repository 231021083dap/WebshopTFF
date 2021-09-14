using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.DB.Entities;

namespace WebshopAPI.Repositories
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllCategories();
    }
    public class CategoryRepo : ICategoryRepo
    {
        private readonly WebshopContext _context;

        public CategoryRepo(WebshopContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Category
                .ToListAsync();
        }
    }
}
