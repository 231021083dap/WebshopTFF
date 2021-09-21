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

namespace WebshopTest.OrderTest
{
    public class OrderServiceTest
    {
        private readonly OrdersService _sut;
        private readonly Mock<IOrdersRepo> _orderRepo = new();
        private readonly Mock<IUserRepo> _userRepo = new();

        public OrderServiceTest()
        {
            _sut = new OrdersService(_orderRepo.Object, _userRepo.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfOrdersResponse_WhenOrdersExists()
        {
            //Arrange
            List<Orders> order = new List<Orders>();

            order.Add(new Orders
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping",
                User = new()
                {
                    UserId = 1,
                    RoleId = 1,
                    Email = "Test@gmail.com",
                    Phone = "20202020",
                    Password = "TestTest",
                    FirstName = "Anders",
                    MiddleName = "Er",
                    LastName = "Noob",
                    Address = "Noobstreet",
                    PostalCode = "1337"
                }
            });

            order.Add(new Orders
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping",
                User = new()
                {
                    UserId = 1,
                    RoleId = 1,
                    Email = "Test@gmail.com",
                    Phone = "20202020",
                    Password = "TestTest",
                    FirstName = "Alex",
                    MiddleName = "Er",
                    LastName = "Noob",
                    Address = "Noobstreet",
                    PostalCode = "1337"
                }
            });

            _orderRepo
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(order);

            //Act
            var result = await _sut.GetAllOrders();


            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<OrderResponse>>(result);
        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfOrderesponse_WhenNoOrderxists()
        {
            //Arrange
            List<Orders> order = new List<Orders>();

            _orderRepo
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(order);


            //Act
            var result = await _sut.GetAllOrders();


            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<OrderResponse>>(result);

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfOrdersResponse_WhenNoOrdersExists()
        {
            //Arrange
            List<Orders> order = new List<Orders>();

            _orderRepo
                .Setup(s => s.GetAllOrders())
                .ReturnsAsync(order);


            //Act
            var result = await _sut.GetAllOrders();


            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<OrderResponse>>(result);

        }


        [Fact]
        public async void GetById_ShouldReturnOrderResponse_WhenOrderExists()
        {
            int orderid = 1;

            Orders order = new()
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping",
                User = new()
                {
                    UserId = 1,
                    RoleId = 1,
                    Email = "Test@gmail.com",
                    Phone = "20202020",
                    Password = "TestTest",
                    FirstName = "Anders",
                    MiddleName = "Er",
                    LastName = "Noob",
                    Address = "Noobstreet",
                    PostalCode = "1337"
                }
            };

            _orderRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(order);

            //Act
            var result = await _sut.GetById(orderid);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<OrderResponse>(result);
            Assert.Equal(order.OrderId, result.OrderId);
            Assert.Equal(order.UserId, result.UserId);
            Assert.Equal(order.OrderStatus, result.OrderStatus);
            

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenOrderDoesNotExists()
        {
            int orderid = 1;

            _orderRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(orderid);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async void Create_ShouldReturnOrderResponse_WhenCreateIsSuccessful()
        {
            //Arrange
            NewOrder newOrder = new()
            {                
                UserId = 2,
                OrderStatus = "Processing",
            };

            int orderid = 1;

            Orders order = new()
            {
                OrderId = orderid,
                UserId = 2,
                OrderStatus = "Processing",
            };

            _orderRepo
                .Setup(s => s.Create(It.IsAny<Orders>()))
                .ReturnsAsync(order);

            User user = new()
            {
                UserId = 1,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            _userRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(user);


            //Act
            var result = await _sut.Create(newOrder);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OrderResponse>(result);
            Assert.Equal(orderid, result.OrderId);
            Assert.Equal(newOrder.UserId, result.UserId);
            Assert.Equal(newOrder.OrderStatus, result.OrderStatus);

        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedOrderResponse_WhenUpdateIsSuccessful()
        {
            //Arrange
            UpdateOrder updateOrder = new()
            {
                UserId = 3,
                OrderStatus = "Shipping",
            };

            int orderid = 1;

            Orders order = new()
            {
                OrderId = orderid,
                UserId = 3,
                OrderStatus = "Shipping",
            };

            _orderRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Orders>()))
                .ReturnsAsync(order);

            User user = new()
            {
                UserId = 1,
                RoleId = 1,
                Email = "Test@gmail.com",
                Phone = "20202020",
                Password = "TestTestTest",
                FirstName = "Anders",
                MiddleName = "Er",
                LastName = "Noob",
                Address = "Noobstreet",
                PostalCode = "1337"
            };

            _userRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(user);


            //Act
            var result = await _sut.Update(orderid, updateOrder);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OrderResponse>(result);
            Assert.Equal(orderid, result.OrderId);            
            Assert.Equal(updateOrder.UserId, result.UserId);
            Assert.Equal(updateOrder.OrderStatus, result.OrderStatus);            

        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenUpdateFailed()
        {
            //Arrange
            UpdateOrder updateOrder = new()
            {
                OrderId = 1,
                UserId = 3,
                OrderStatus = "Shipping",
            };

            int orderid = 1;

            _orderRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Orders>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.Update(orderid, updateOrder);

            //Assert
            Assert.Null(result);


        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            //Arrange
            int orderid = 1;

            Orders order = new()
            {
                OrderId = orderid,
                UserId = 1,
                OrderStatus = "Cancelled"
            };

            _orderRepo
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(order);

            //Act
            var result = await _sut.Delete(orderid);

            //Assert
            Assert.True(result);            

        }


    }
}
