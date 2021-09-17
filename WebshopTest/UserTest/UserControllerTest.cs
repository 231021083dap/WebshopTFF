using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Controllers;
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
        }


        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoDataExists()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            //Act

            //Assert
        }


        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenDataDoesNotExist()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            //Act

            //Assert
        }


        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            //Act

            //Assert
        }


        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsUpdated()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            //Act

            //Assert
        }


        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenDataIsDeleted()
        {
            //Arrange

            //Act

            //Assert
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
