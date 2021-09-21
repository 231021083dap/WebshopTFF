using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;
using WebshopAPI.DTO;
using WebshopAPI.Repositories;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.UserTest
{
    public class UserServiceTest
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepo> _userRepo = new();


        public UserServiceTest()
        {
            _sut = new UserService(_userRepo.Object);

        }

        [Fact]
        public async void GetAll_ShouldReturnListOfUsersResponse_WhenUsersExists()
        {
            //Arrange
            List<User> user = new();

            user.Add(new User
            {
                UserId = 1,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
                UserRole = new()
                {
                    RoleId = 1,
                    RoleName = "Customer"
                }
            });
            user.Add(new User
            {
                UserId = 2,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
                UserRole = new()
                {
                    RoleId = 1,
                    RoleName = "Customer"
                }
            });

            _userRepo
                .Setup(s => s.GetAllUsers())
                .ReturnsAsync(user);

            //Act
            var result = await _sut.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<UserResponse>>(result);

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfUsersResponse_WhenNoUsersExists()
        {
            //Arrange
            List<User> user = new List<User>();

            _userRepo
                .Setup(s => s.GetAllUsers())
                .ReturnsAsync(user);
            //Act
            var result = await _sut.GetAllUsers();
            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<UserResponse>>(result);

        }


        [Fact]
        public async void GetById_ShouldReturnUserResponse_WhenUserExists()
        {
            //Arrange
            int userid = 1;

            User user = new()
            {
                UserId = userid,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
                UserRole = new()
                {
                    RoleId = 1,
                    RoleName = "Customer"
                }
            };

            _userRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(user);

            //Act
            var result = await _sut.GetById(userid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<UserResponse>(result);
            Assert.Equal(user.UserId, result.UserId);
            Assert.Equal(user.RoleId, result.RoleId);
            Assert.Equal(user.Email , result.Email);
            Assert.Equal(user.Phone , result.Phone);
            Assert.Equal(user.Password , result.Password);
            Assert.Equal(user.FirstName , result.FirstName);
            Assert.Equal(user.MiddleName , result.MiddleName);
            Assert.Equal(user.LastName , result.LastName);
            Assert.Equal(user.Address , result.Address);
            Assert.Equal(user.PostalCode , result.PostalCode);

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenUserDoesNotExists()
        {
            //Arrange
            int userid = 1;

            _userRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(userid);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async void Create_ShouldReturnUserResponse_WhenCreateIsSuccessful()
        {
            //Arrange
            NewUser newUser = new()
            {
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
            };

            int userid = 1;

            User user = new()
            {
                UserId = userid,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
            };

            _userRepo
                .Setup(s => s.Create(It.IsAny<User>()))
                .ReturnsAsync(user);

            Role role = new()
            {
                RoleId = 1,
                RoleName = "Customer"
            };

            _userRepo
                .Setup(s => s.GetByRoleId(It.IsAny<int>()))
                .ReturnsAsync(role);

            //Act
            var result = await _sut.Create(newUser);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<UserResponse>(result);
            Assert.Equal(userid, result.UserId);
            Assert.Equal(newUser.RoleId, result.RoleId);
            Assert.Equal(newUser.Email , result.Email);
            Assert.Equal(newUser.Phone , result.Phone);
            Assert.Equal(newUser.Password , result.Password);
            Assert.Equal(newUser.FirstName , result.FirstName);
            Assert.Equal(newUser.MiddleName , result.MiddleName);
            Assert.Equal(newUser.LastName , result.LastName);
            Assert.Equal(newUser.Address , result.Address);
            Assert.Equal(newUser.PostalCode , result.PostalCode);
        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedUserResponse_WhenUpdateIsSuccessful()
        {
            //Arrange
            UpdateUser updateUser = new()
            {
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
            };

            int userid = 1;
            User user = new()
            {
                UserId = userid,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
            };

            _userRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync(user);

            Role role = new()
            {
                RoleId = 1,
                RoleName = "Customer"
            };

            _userRepo
                .Setup(s => s.GetByRoleId(It.IsAny<int>()))
                .ReturnsAsync(role);



            //Act
            var result = await _sut.Update(userid, updateUser);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<UserResponse>(result);
            Assert.Equal(userid, result.UserId);
            Assert.Equal(updateUser.RoleId , result.RoleId);
            Assert.Equal(updateUser.Email , result.Email);
            Assert.Equal(updateUser.Phone , result.Phone);
            Assert.Equal(updateUser.Password , result.Password);
            Assert.Equal(updateUser.FirstName , result.FirstName);
            Assert.Equal(updateUser.MiddleName , result.MiddleName);
            Assert.Equal(updateUser.LastName , result.LastName);
            Assert.Equal(updateUser.Address , result.Address);
            Assert.Equal(updateUser.PostalCode , result.PostalCode);

        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenUpdateFailed()
        {
            //Arrange
            UpdateUser updateUser = new()
            {
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
            };
            int userid = 1;

            _userRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.Update(userid, updateUser);
            //Assert
            Assert.Null(result);

        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            //Arrange
            int userid = 1;

            User user = new()
            {
                UserId = userid,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337",
            };

            _userRepo
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(user);

            //Act
            var result = await _sut.Delete(userid);
            //Assert
            Assert.True(result);

        }
    }
}
