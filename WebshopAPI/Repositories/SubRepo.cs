using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.DB.Entities;

namespace WebshopAPI.Repositories
{
    public interface ISubRepo
    {
        Task<List<SubCategory>> GetAllSubs();
        Task<SubCategory> GetById(int SubId);
        Task<SubCategory> Create(SubCategory sub);
        Task<SubCategory> Update(int SubId, SubCategory sub);
        Task<SubCategory> Delete(int SubId);
    }
    public class SubRepo : ISubRepo
    {
        private readonly WebshopContext _context;
        public SubRepo(WebshopContext context)
        {
            _context = context;
        }
        public async Task<List<SubCategory>> GetAllSubs()
        {
            return await _context.SubCategory
                .Include(c => c.Category)
                .ToListAsync();
        }
        public async Task<SubCategory> GetById(int SubId)
        {
            return await _context.SubCategory
                .Include(c => c.Category)
                .FirstOrDefaultAsync(u => u.SubId == SubId);
        }

        public async Task<SubCategory> Create(SubCategory Sub)
        {
            _context.SubCategory.Add(Sub);
            await _context.SaveChangesAsync();
            return Sub;
        }
        public async Task<SubCategory> Update(int SubId, SubCategory sub)
        {
            SubCategory UpdateSub = await _context.SubCategory.FirstOrDefaultAsync(u => u.SubId == SubId);
            if (UpdateSub != null)
            {
                UpdateSub.SubName = sub.SubName;
                UpdateSub.CategoryId= sub.CategoryId;

                await _context.SaveChangesAsync();
            }
            return UpdateSub;
        }

        public async Task<SubCategory> Delete(int SubId)
        {
            SubCategory newSub = await _context.SubCategory.FirstOrDefaultAsync(u => u.SubId == SubId);
            if (newSub != null)
            {
                _context.SubCategory.Remove(newSub);
                await _context.SaveChangesAsync();
            }
            return newSub;
        }
    }
}
