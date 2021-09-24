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
        Task<List<UserRoleResponse>> GetUserRoles();
        Task<UserResponse> GetById(int UserId);
        Task<UserResponse> Create(NewUser newUser);
        Task<UserResponse> Update(int UserId, UpdateUser updateUser);
        Task<bool> Delete(int UserId);
        //Task<UserRoleResponse> GetByRoleId(int RoleId);
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

            List<User> Users = await _UserRepo.GetAllUsers();
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
                    RoleName = u.UserRole.RoleName,
                    RoleId = u.UserRole.RoleId
                }

            }).ToList();
        }

        public async Task<List<UserRoleResponse>> GetUserRoles()
        {

            List<Role> Roles = await _UserRepo.GetUserRoles();
            //lambda
            return Roles.Select(u => new UserRoleResponse
            {
                RoleName = u.RoleName,
                RoleId = u.RoleId

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
                    RoleName = user.UserRole.RoleName,
                    RoleId = user.UserRole.RoleId
                }

            };
        }
        public async Task<UserResponse> Create(NewUser newUser)
        {
            User user = new()
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
            if (user != null)
            {
                user.UserRole = await _UserRepo.GetByRoleId(user.RoleId);

                return new UserResponse
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
                        RoleName = user.UserRole.RoleName,
                        RoleId = user.UserRole.RoleId
                    }
                };
            }
            return null;
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
            if (user != null)
            {
                user.UserRole = await _UserRepo.GetByRoleId(user.RoleId);
                return new UserResponse
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
                        RoleName = user.UserRole.RoleName,
                        RoleId = user.UserRole.RoleId
                    }
                };
            }
            return null;
        }

        public async Task<bool> Delete(int UserId)
        {
            var result = await _UserRepo.Delete(UserId);
            return true;
        }

        // ROLE //

        //public async Task<UserRoleResponse> GetByRoleId(int RoleId)
        //{
        //    Role role = await _UserRepo.GetByRoleId(RoleId);

        //    return role == null ? null : new UserRoleResponse


        //    {
        //        RoleName = role.RoleName,
        //        RoleId = role.RoleId
        //    };


        //}
    }
}


