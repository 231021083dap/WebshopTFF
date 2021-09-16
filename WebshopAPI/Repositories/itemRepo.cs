using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.DB.Entities;

namespace WebshopAPI.Repositories
{
    public interface IItemRepo 
    { 
    Task<List<Item>> GetAllItems();
    Task<Item> GetById(int ItemId);
    Task<Item> Create(Item item);
    Task<Item> Update(int ItemId, Item item);
    Task<Item> Delete(int ItemId);
    }
    public class ItemRepo : IItemRepo
    {
        private readonly WebshopContext _context;
        public ItemRepo(WebshopContext context)
        {
            _context = context;
        }


        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Item
                .ToListAsync();
        }
        public async Task<Item> GetById(int ItemId)
        {
            return await _context.Item
                .FirstOrDefaultAsync(u => u.ItemId == ItemId);
        }

        public async Task<Item> Create(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Item> Update(int ItemId, Item item)
        {
            Item UpdateItem = await _context.Item.FirstOrDefaultAsync(u => u.ItemId == ItemId);
            if (UpdateItem != null)
            {
                UpdateItem.ItemName = item.ItemName;
                UpdateItem.SubCategoryId = item.SubCategoryId;
                UpdateItem.ItemPrice = item.ItemPrice;
                UpdateItem.ItemDiscount = item.ItemDiscount;
                UpdateItem.ItemAmount = item.ItemAmount;
                UpdateItem.ItemStatus = item.ItemStatus;
            }
            return UpdateItem;
        }

        public async Task<Item> Delete(int ItemId)
        {
            Item NewItem = await _context.Item.FirstOrDefaultAsync(u => u.ItemId == ItemId);
            if (NewItem != null)
            {
                _context.Item.Remove(NewItem);
                await _context.SaveChangesAsync();
            }
            return NewItem;
        }

    }
}
