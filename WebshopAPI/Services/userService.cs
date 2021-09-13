//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebshopAPI.DB.Entities;
//using WebshopAPI.DTO;
//using WebshopAPI.Responses;

//namespace WebshopAPI.Services
//{
//    public class UserService
//    {
//        public interface IUserService
//        {
//            //    //CRUD
//            Task<List<UserResponse>> GetAllUsers();
//            Task<UserResponse> GetById(int UserId);
//            Task<UserResponse> Create(NewUser NewUser);
//            Task<UserResponse> Update(int UserId, UpdateUser UpdateUser);
//            Task<bool> Delete(int UserId);            

//            public class UserService : IUserService
//            {
//              //  private readonly IUserRepo _UserRepo;
//                //CTOR
//                //public UserService(IUserRepo UserRepo)
//                //{
//                //    _UserRepo = UserRepo;

//                //}


//                public async Task<List<UserResponse>> GetAllUsers()
//                {
//                    //List<UserResponse> Users = new();
//                    List<User> Users = await _UserRepo.GetAll();
//                    //lambda
//                    return Users.Select(u => new UserResponse
//                    {
//                        UserId = u.UserId,
//                        UserRoleId = u.UserRoleId,
//                        Email = u.Email,
//                        Phone = u.Phone,
//                        Password = u.Password,
//                        FirstName = u.FirstName,
//                        LastName = u.LastName,
//                        MiddleName = u.MiddleName,
//                        Address = u.Address,
//                        PostalCode = u.PostalCode
//                    }).ToList();
//                }

//                public async Task<UserResponse> GetById(int UserId)
//                {
//                    User User = await _UserRepo.GetById(UserId);
//                    return User == null ? null : new UserResponse
//                    {
//                        UserId = User.UserId,
//                        UserRoleId = User.UserRoleId,
//                        Email = User.Email,
//                        Phone = User.Phone,
//                        Password = User.Password,
//                        FirstName = User.FirstName,
//                        LastName = User.LastName,
//                        MiddleName = User.MiddleName,
//                        Address = User.Address,
//                        PostalCode = User.PostalCode
//                    };
//                }
//                public async Task<UserResponse> Create(NewUser NewUser)
//                {
//                    User User = new User
//                    {
//                        UserRoleId = NewUser.UserRoleId,
//                        Email = NewUser.Email,
//                        Phone = NewUser.Phone,
//                        Password = NewUser.Password,
//                        FirstName = NewUser.FirstName,
//                        LastName = NewUser.LastName,
//                        MiddleName = NewUser.MiddleName,
//                        Address = NewUser.Address,
//                        PostalCode = NewUser.PostalCode
//                    };
//                    User = await _UserRepo.Create(User);

//                    //Turnary operator, hvis værdien er null -> return, hvis værdien IKKE er null -> continue
//                    return User == null ? null : new UserResponse
//                    {
//                        UserId = User.UserId,
//                        UserRoleId = User.UserRoleId,
//                        Email = User.Email,
//                        Phone = User.Phone,
//                        Password = User.Password,
//                        FirstName = User.FirstName,
//                        LastName = User.LastName,
//                        MiddleName = User.MiddleName,
//                        Address = User.Address,
//                        PostalCode = User.PostalCode
//                    };
//                }


//                public async Task<UserResponse> Update(int UserId, UpdateUser UpdateUser)
//                {
//                    User User = new User
//                    {
//                        UserRoleId = UpdateUser.UserRoleId,
//                        Email = UpdateUser.Email,
//                        Phone = UpdateUser.Phone,
//                        Password = UpdateUser.Password,
//                        FirstName = UpdateUser.FirstName,
//                        LastName = UpdateUser.LastName,
//                        MiddleName = UpdateUser.MiddleName,
//                        Address = UpdateUser.Address,
//                        PostalCode = UpdateUser.PostalCode
//                    };
//                    User = await _UserRepo.Update(UserId, User);

//                    return User == null ? null : new UserResponse
//                    {
//                        UserRoleId = User.UserRoleId,
//                        Email = User.Email,
//                        Phone = User.Phone,
//                        Password = User.Password,
//                        FirstName = User.FirstName,
//                        LastName = User.LastName,
//                        MiddleName = User.MiddleName,
//                        Address = User.Address,
//                        PostalCode = User.PostalCode
//                    };
//                }

//                public async Task<bool> Delete(int UserId)
//                {
//                    var result = await _UserRepo.Delete(UserId);
//                    return true;
//                }
//            }
//        }
//    }
//}
