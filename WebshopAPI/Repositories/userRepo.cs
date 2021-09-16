using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.DB.Entities;
using WebshopAPI.DTO;

namespace WebshopAPI.Repositories
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int UserId);
        Task<User> Create(User user);
        Task<User> Update(int UserId, User user);
        Task<User> Delete(int UserId);
    }
    public class UserRepo : IUserRepo
    {
        private readonly WebshopContext _context;
        public UserRepo(WebshopContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User
                .Include(r => r.UserRole)
                .ToListAsync();
        }
        public async Task<User> GetById(int UserId)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.UserId == UserId);
        }

        public async Task<User> Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(int UserId, User user)
        {
            User UpdateUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == UserId);
            if (UpdateUser != null)
            {
                UpdateUser.RoleId = user.RoleId;
                UpdateUser.Email = user.Email;
                UpdateUser.Phone = user.Phone;
                UpdateUser.Password = user.Password;
                UpdateUser.FirstName = user.FirstName;
                UpdateUser.LastName = user.LastName;
                UpdateUser.MiddleName = user.MiddleName;
                UpdateUser.Address = user.Address;
                UpdateUser.PostalCode = user.PostalCode;

                await _context.SaveChangesAsync();
            }
            return UpdateUser;
        }

        public async Task<User> Delete(int UserId)
        {
            User NewUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == UserId);
            if (NewUser != null)
            {
                _context.User.Remove(NewUser);
                await _context.SaveChangesAsync();
            }
            return NewUser;
        }
    }
}
