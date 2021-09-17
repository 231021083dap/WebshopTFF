using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Controllers;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.Order
{
    public class OrderControllerTest
    {
        private readonly OrdersController _sut;
        private readonly Mock<IOrdersService> _ordersService = new();

        public OrderControllerTest()
        {
            _sut = new OrdersController(_ordersService.Object);
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
