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

namespace WebshopTest.OrderTest
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
            List<OrderResponse> orders = new();
            orders.Add(new OrderResponse
            {
                OrderId = 1,
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Shipping"
            });
            orders.Add(new OrderResponse
            {
                OrderId = 2,
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Delivered"
            });

            _ordersService
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(orders);
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
            List<OrderResponse> orders = new();

            _ordersService
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(orders);
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
            _ordersService
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(() => null);

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
            _ordersService
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(() => throw new Exception("This is an exception"));

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
            int orderid = 1;

            OrderResponse order = new()
            {
                OrderId = orderid,
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Shipping",
            };

            _ordersService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(order);

            //Act
            var result = await _sut.GetById(orderid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenDataDoesNotExist()
        {
            //Arrange
            int orderid = 1;

            _ordersService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(orderid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _ordersService
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
            int orderid = 1;

            NewOrder newOrder = new()
            {
             
                UserId = 1,                
                OrderStatus = "Shipping"
            };

            OrderResponse order = new()
            {
                OrderId = orderid,
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Shipping"
            };

            _ordersService
                .Setup(s => s.Create(It.IsAny<NewOrder>()))
                .ReturnsAsync(order);
            //Act
            var result = await _sut.Create(newOrder);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            NewOrder newOrder = new()
            {

                UserId = 1,
                OrderStatus = "Shipping"
            };

            _ordersService
                .Setup(s => s.Create(It.IsAny<NewOrder>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Create(newOrder);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsUpdated()
        {
            //Arrange
            int orderid = 1;
            UpdateOrder updateOrder = new()
            {

                UserId = 1,
                OrderStatus = "Shipping"
            };
            OrderResponse order = new()
            {
                OrderId = orderid,
                UserId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = "Shipping"
            };


            _ordersService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder>()))
                .ReturnsAsync(order);

            //Act
            var result = await _sut.Update(orderid, updateOrder);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int orderid = 1;

            UpdateOrder updateOrder = new()
            {

                UserId = 1,
                OrderStatus = "Shipping"
            };

            _ordersService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Update(orderid, updateOrder);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenDataIsDeleted()
        {
            //Arrange
            int orderid = 1;

            _ordersService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            //Act
            var result = await _sut.Delete(orderid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(204, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int orderid = 1;

            _ordersService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));

            //Act
            var result = await _sut.Delete(orderid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
