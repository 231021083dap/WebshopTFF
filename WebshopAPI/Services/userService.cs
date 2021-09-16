using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;
using WebshopAPI.DTO;
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
    }



    public class UserService : IUserService
    {
        private readonly IUserRepo _UserRepo;
        //CTOR
        public UserService(IUserRepo UserRepo)
        {
            _UserRepo = UserRepo;

        }


        public async Task<List<UserResponse>> GetAllUsers()
        {
            List<UserResponse> Users = new();
            List<User> User = await _UserRepo.GetAllUsers();
            //lambda
            return Users.Select(u => new UserResponse
            {
                UserId = u.UserId,
                RoleId = u.RoleId,
                Email = u.Email,
                Phone = u.Phone,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                MiddleName = u.MiddleName,
                Address = u.Address,
                PostalCode = u.PostalCode,
                UserRole = new UserRoleResponse
                {
                    RoleName = u.UserRole.RoleName
                }

            }).ToList();
        }

        public async Task<UserResponse> GetById(int UserId)
        {
            User user = await _UserRepo.GetById(UserId);

            return user == null ? null : new UserResponse
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Address = user.Address,
                PostalCode = user.PostalCode,
                UserRole = new UserRoleResponse
                {
                    RoleName = user.UserRole.RoleName
                }

            };
        }
        public async Task<UserResponse> Create(NewUser newUser)
        {
            User user = new User
            {
                RoleId = newUser.RoleId,
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

            //Turnary operator, hvis værdien er null -> return, hvis værdien IKKE er null -> continue
            return user == null ? null : new UserResponse
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Address = user.Address,
                PostalCode = user.PostalCode,
                UserRole = new UserRoleResponse
                {
                    RoleName = user.UserRole.RoleName
                }

            };
        }


        public async Task<UserResponse> Update(int UserId, UpdateUser updateUser)
        {
            User user = new User
            {
                RoleId = updateUser.RoleId,
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

            return user == null ? null : new UserResponse
            {
                RoleId = user.RoleId,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Address = user.Address,
                PostalCode = user.PostalCode,
                UserRole = new UserRoleResponse
                {
                    RoleName = user.UserRole.RoleName
                }
            };
        }

        public async Task<bool> Delete(int UserId)
        {
            var result = await _UserRepo.Delete(UserId);
            return true;
        }
    }
}


