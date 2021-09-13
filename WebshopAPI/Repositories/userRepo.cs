//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebshopAPI.DB;
//using WebshopAPI.DB.Entities;
//using WebshopAPI.DTO;

//namespace WebshopAPI.Repositories
//{
//    public interface IUserRepo
//    {
//        Task<List<User>> GetAllUsers();
//        Task<User> GetById(int UserId);
//        Task<User> Create(NewUser NewUser);
//        Task<User> Update(int UserId, UpdateUser updateUser);
//        Task<User> Delete(int UserId);
//    }
//    public class UserRepo : IUserRepo
//    {
//        private readonly WebshopContext _context;
//        public UserRepo(WebshopContext context)
//        {
//            _context = context;
//        }
//        public async Task<List<User>> GetAllUsers()
//        {
//            return await _context.User
//                .ToListAsync();
//        }
//        public async Task<User> GetById(int UserId)
//        {
//            return await _context.User
//                .FirstOrDefaultAsync(u => u.UserId == UserId);
//        }

//        public async Task<User> Create(NewUser NewUser)
//        {
//            _context.User.Add(NewUser);
//            await _context.SaveChangesAsync();
//            return NewUser;
//        }
//        public async Task<User> Update(int UserId, UpdateUser updateUser)
//        {
//            User UpdateUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == UserId);
//            if(UpdateUser != null)
//            {                
//                UpdateUser.UserRoleId = updateUser.UserRoleId;
//                UpdateUser.Email = updateUser.Email;
//                UpdateUser.Phone = updateUser.Phone;
//                UpdateUser.Password = updateUser.Password;
//                UpdateUser.FirstName = updateUser.FirstName;
//                UpdateUser.LastName = updateUser.LastName;
//                UpdateUser.MiddleName = updateUser.MiddleName;
//                UpdateUser.Address = updateUser.Address;
//                UpdateUser.PostalCode = updateUser.PostalCode;
//            }
//        }

//        public async Task<User> Delete(int UserId)
//        {
//            User NewUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == UserId);
//            if (NewUser != null)
//            {
//                _context.User.Remove(NewUser);
//                await _context.SaveChangesAsync();
//            }
//            return NewUser;
//        }
//    }
//}
