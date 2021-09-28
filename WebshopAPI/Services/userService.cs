using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Authorization;
using WebshopAPI.DB.Entities;
using WebshopAPI.DTO;
using WebshopAPI.Helpers;
using WebshopAPI.Repositories;
using WebshopAPI.Responses;

namespace WebshopAPI.Services
{
    public interface IUserService
    {
        //    //CRUD
        Task<List<UserResponse>> GetAllUsers();        
        Task<UserResponse> GetById(int UserId);
        Task<UserResponse> Create(NewUser newUser);
        Task<UserResponse> Update(int UserId, UpdateUser updateUser);
        Task<bool> Delete(int UserId);
        //Task<UserRoleResponse> GetByRoleId(int RoleId);
        Task<LoginResponse> Authenticate(NewLogin login);
    }



    public class UserService : IUserService
    {
        private readonly IUserRepo _UserRepo;
        private readonly IJwtUtils _jwtUtils;

        
        public UserService(IUserRepo UserRepo, IJwtUtils jwtUtils)
        {
            _UserRepo = UserRepo;
            _jwtUtils = jwtUtils;
        }


        public async Task<List<UserResponse>> GetAllUsers()
        {

            List<User> Users = await _UserRepo.GetAllUsers();
            //lambda
            return Users.Select(u => new UserResponse
            {
                UserId = u.UserId,
                Role = u.Role,
                Email = u.Email,
                Phone = u.Phone,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                MiddleName = u.MiddleName,
                Address = u.Address,
                PostalCode = u.PostalCode,
               

            }).ToList();
        }       


        public async Task<UserResponse> GetById(int UserId)
        {
            User user = await _UserRepo.GetById(UserId);

            return user == null ? null : new UserResponse
            {
                UserId = user.UserId,
                Role = Helpers.Role.Employee,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Address = user.Address,
                PostalCode = user.PostalCode,               
            };
        }
        public async Task<UserResponse> Create(NewUser newUser)
        {
            User user = new()
            {
                Role = Helpers.Role.Employee,
                Email = newUser.Email,
                Phone = newUser.Phone,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                MiddleName = newUser.MiddleName,
                Address = newUser.Address,
                PostalCode = newUser.PostalCode
            };
            user = await _UserRepo.Create(user);

            return userResponse(user);

              
        }


        public async Task<UserResponse> Update(int UserId, UpdateUser updateUser)
        {
            User user = new User
            {
                UserId = 1,
                Role = updateUser.Role,
                Email = updateUser.Email,
                Phone = updateUser.Phone,
                Password = updateUser.Password,
                FirstName = updateUser.FirstName,
                LastName = updateUser.LastName,
                MiddleName = updateUser.MiddleName,
                Address = updateUser.Address,
                PostalCode = updateUser.PostalCode
            };
            user = await _UserRepo.Update(UserId, user);

            return userResponse(user);
            
        }

        public async Task<bool> Delete(int UserId)
        {
            var result = await _UserRepo.Delete(UserId);
            return true;
        }

        public async Task<LoginResponse> Authenticate(NewLogin login)
        {
            User user = await _UserRepo.GetByEmail(login.Email);
            if (user == null)
            {
                return null;
            }

            if (user.Password == login.Password)
            {
                LoginResponse response = new LoginResponse
                {
                    Id = user.UserId,
                    Email = user.Email,                    
                    Role = user.Role,
                    Token = _jwtUtils.GenerateJwtToken(user)
                };
                return response;
            }

            return null;
        }
        private UserResponse userResponse(User user)
        {
            return user == null ? null : new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,                
                Role = user.Role
            };
        }
    }
}


