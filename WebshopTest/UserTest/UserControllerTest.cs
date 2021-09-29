using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Controllers;
using WebshopAPI.DTO;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.UserTest
{
    public class UserControllerTest
    {
        private readonly UserController _sut;
        private readonly Mock<IUserService> _userService = new();

        public UserControllerTest()
        {
            _sut = new UserController(_userService.Object);
            _sut.ControllerContext.HttpContext = new DefaultHttpContext() { };
        }


        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            List<UserResponse> user = new();

            user.Add(new UserResponse
            {
                UserId = 1,
                Role = WebshopAPI.Helpers.Role.Employee,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"

            });

            user.Add(new UserResponse
            {
                UserId = 2,
                Role = WebshopAPI.Helpers.Role.Customer,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Alex",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            });

            _userService
                .Setup(s => s.GetAllUsers())
                .ReturnsAsync(user);
            //Act
            var result = await _sut.GetAll();


            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoDataExists()
        {
            //Arrange
            List<UserResponse> user = new();

            _userService
                .Setup(s => s.GetAllUsers())
                .ReturnsAsync(user);

            //Act
            var result = await _sut.GetAll();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //Arrange
            _userService
                .Setup(s => s.GetAllUsers())
                .ReturnsAsync(() =>  null);

            //Act
            var result = await _sut.GetAll();


            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _userService
                .Setup(s => s.GetAllUsers())
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.GetAll();

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            int userid = 1;

            _sut.ControllerContext.HttpContext.Items["User"] = new UserResponse
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Customer
            };

            UserResponse user = new()
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Admin,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            _userService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(user);

            //Act
            var result = await _sut.GetById(userid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenDataDoesNotExist()
        {
            //Arrange
            int userid = 1;

            _sut.ControllerContext.HttpContext.Items["User"] = new UserResponse
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Admin
            };

            _userService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(userid);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _sut.ControllerContext.HttpContext.Items["User"] = new UserResponse
            {
                UserId = 1,
                Role = WebshopAPI.Helpers.Role.Admin
            };

            _userService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));
            //Act
            var result = await _sut.GetById(1);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            //Arrange
            int userid = 1;

            NewUser newuser = new()
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
            };
            UserResponse user = new()
            {
                UserId = userid,
                Role = WebshopAPI.Helpers.Role.Customer,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            _userService
                .Setup(s => s.Create(It.IsAny<NewUser>()))
                .ReturnsAsync(user);
            //Act
            var result = await _sut.Create(newuser);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            NewUser newuser = new()
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
            };

            _userService
                .Setup(s => s.Create(It.IsAny<NewUser>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Create(newuser);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsUpdated()
        {
            //Arrange
            int userId = 1;

            UpdateUser updateUser = new()
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
            UserResponse user = new()
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
            };

            _userService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateUser>()))
                .ReturnsAsync(user);

            //Act
            var result = await _sut.Update(userId, updateUser);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int userId = 1;

            UpdateUser updateUser = new()
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

            _userService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateUser>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));
            //Act
            var result = await _sut.Update(userId, updateUser);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenDataIsDeleted()
        {
            //Arrange
            int userrole = 1;

            _userService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);
            //Act
            var result = await _sut.Delete(userrole);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int userrole = 1;

            _userService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));
            //Act
            var result = await _sut.Delete(userrole);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnUnAuthorized_WhenUserIsNotLoggedOn()
        {
            // Arrange
            _sut.ControllerContext.HttpContext.Items["Customer"] = null;

            // Act
            var result = await _sut.GetById(1);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(401, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnCustomer_WhenCustomerIsLoggedOnAsCustomer()
        {
            // Arrange
            _sut.ControllerContext.HttpContext.Items["User"] = new UserResponse
            {
                UserId = 2,
                Role = WebshopAPI.Helpers.Role.Customer
            };

            UserResponse user = new UserResponse
            {
                UserId = 2,
                FirstName = "Benny",
                MiddleName = "Lenny",
                LastName = "Genny",
                Email = "benny@mail.dk",
                Role = WebshopAPI.Helpers.Role.Customer
            };

            _userService
                .Setup(u => u.GetById(It.IsAny<int>()))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.GetById(2);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
    }
}
