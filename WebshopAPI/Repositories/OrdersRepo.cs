using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.DB.Entities;

namespace WebshopAPI.Repositories
{
    public interface IOrdersRepo
    {
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetById(int OrderId);
        Task<Orders> Create(Orders Order);
        Task<Orders> Update(int OrderId, Orders Order);
        Task<Orders> Delete(int OrderId);
    }

    public class OrdersRepo : IOrdersRepo
    {
        private readonly WebshopContext _context;

        public OrdersRepo(WebshopContext context)
        {
            _context = context;
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            return await _context.Orders
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<Orders> GetById(int OrderId)
        {
            return await _context.Orders
                .Include(u => u.User)
                .FirstOrDefaultAsync(u => u.OrderId == OrderId);
        }

        public async Task<Orders> Create(Orders Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
            return Order;
        }

        public async Task<Orders> Update(int OrderId, Orders Order)
        {
            Orders updateOrder = await _context.Orders.FirstOrDefaultAsync(u => u.OrderId == OrderId);
            if(updateOrder != null)
            {
                updateOrder.UserId = Order.UserId;
                updateOrder.OrderStatus = Order.OrderStatus;

                await _context.SaveChangesAsync();
            }

            return updateOrder;
        }

        public async Task<Orders> Delete(int OrderId)
        {
            Orders newOrder = await _context.Orders.FirstOrDefaultAsync(u => u.OrderId == OrderId);
            if (newOrder != null)
            {
                _context.Orders.Remove(newOrder);
                await _context.SaveChangesAsync();
            }

            return newOrder;
        }
    }
}
