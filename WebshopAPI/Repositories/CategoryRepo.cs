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
        Task<Category> GetById(int CategoryId);
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
                .Include(c => c.SubCategory)
                .ToListAsync();
        }

        public async Task<Category> GetById(int CategoryId)
        {
            return await _context.Category
            .FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
        }
    }
}
