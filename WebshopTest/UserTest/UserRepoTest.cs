using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.DB.Entities;
using WebshopAPI.Repositories;
using Xunit;

namespace WebshopTest.UserTest
{
    public class UserRepoTest
    {

        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly UserRepo _sut;

        public UserRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "WebshopUserTest")
                .Options;

            _context = new WebshopContext(_options);

            _sut = new UserRepo(_context);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnListOfUsers_WhenUserExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
           
            await _context.SaveChangesAsync();

            _context.User.Add(
            new User
            {
                Role = WebshopAPI.Helpers.Role.Customer,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            });
            _context.User.Add(
            new User
            {
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Alex",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetAllUsers();


            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task GetAllUsers_ShouldReturnEmptyList_WhenUserExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();


            //Act
            var result = await _sut.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.Empty(result);
        }


        [Fact]
        public async Task GetUserById_ShouldReturnUserObject_WhenUserExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;
           
            await _context.SaveChangesAsync();

            _context.User.Add(
            new User
            {
                UserId = 1,
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Alex",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetById(userid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userid, result.UserId);
        }
        [Fact]
        public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;

            //Act
            var result = await _sut.GetById(userid);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async Task Create_ShouldAddIdToUser_WhenSavingDataToDatabase()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;

            User user = new()
            {
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.Create(user);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userid, result.UserId);

        }
        [Fact]
        public async Task Create_ShouldFail_WhenAddingUserWithExistingId()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            User user = new()
            {
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test23@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            //Act
            Func<Task> action = async () => await _sut.Create(user);

            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }


        [Fact]
        public async Task Update_ShouldChangeValuesOnUserById_WhenUserExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;

            User user = new()
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            User updateUser = new()
            {
                UserId = 2,
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            //Act
            var result = await _sut.Update(userid, updateUser);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userid, result.UserId);
            Assert.Equal(updateUser.Email, result.Email);
            Assert.Equal(updateUser.Phone, result.Phone);
            Assert.Equal(updateUser.Password , result.Password);
            Assert.Equal(updateUser.FirstName , result.FirstName);
            Assert.Equal(updateUser.MiddleName , result.MiddleName);
            Assert.Equal(updateUser.LastName , result.LastName);
            Assert.Equal(updateUser.Address , result.Address);
            Assert.Equal(updateUser.PostalCode , result.PostalCode);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenUserDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;

            User updateUser = new()
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            //Act
            var result = await _sut.Update(userid, updateUser);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async Task Delete_ShouldReturnDeletedUser_WhenUserIsDeleted()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;

            User user = new()
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Test",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.Delete(userid);
            var deleteUser = await _sut.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userid, result.UserId);
            Assert.Empty(deleteUser);
        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenUserDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int userid = 1;

            //Act
            var result = await _sut.Delete(userid);

            //Assert
            Assert.Null(result);
        }

    }
}
