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

namespace WebshopTest.OrderTest
{
    public class OrderRepoTest
    {
        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly OrdersRepo _sut;


        public OrderRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "WebshopOrderTest")
                .Options;

            _context = new WebshopContext(_options);
            _sut = new OrdersRepo(_context);
        }


        [Fact]
        public async Task GetAllOrders_ShouldReturnListOfOrders_WhenOrdersExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.User.Add(
                new User
                {
                    UserId = 1,
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
            await _context.SaveChangesAsync();

            _context.Orders.Add(
            new Orders
                {
                    OrderId = 1,
                    UserId = 1,      
                    OrderStatus = "Shipping"
                });
            _context.Orders.Add(
                new Orders
                {
                    OrderId = 2,
                    UserId = 1,
                    OrderStatus = "Delivered"
                });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetAllOrders();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Orders>>(result);
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task GetAllOrders_ShouldReturnEmptyList_WhenNoOrdersExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _sut.GetAllOrders();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Orders>>(result);
            Assert.Empty(result);

        }


        [Fact]
        public async Task GetOrderById_ShouldReturnOrderObject_WhenOrderExists()
        {
            await _context.Database.EnsureDeletedAsync();

            int orderid = 1;

            _context.User.Add(
                new User
                {
                    UserId = 1,
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
            await _context.SaveChangesAsync();

            _context.Orders.Add(
            new Orders
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetById(orderid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Orders>(result);
            Assert.Equal(orderid, result.OrderId);

        }
        [Fact]
        public async Task GetOrderById_ShouldReturnNull_WhenOrderDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int orderid = 1;


            //Act
            var result = await _sut.GetById(orderid);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task Create_ShouldAddIdToOrder_WhenSavingDataToDatabase()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int hopefullythisId = 1;

            Orders order = new()
            {
                UserId = 1,
                OrderStatus = "Shipping"
            };

            //Act
            var result = await _sut.Create(order);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Orders>(result);
            Assert.Equal(hopefullythisId, result.OrderId);
        }
        [Fact]
        public async Task Create_ShouldFail_WhenAddingOrderWithExistingId()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            Orders order = new ()
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            //Act
            Func<Task> action = async () => await _sut.Create(order);

            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);

        }


        [Fact]
        public async Task Update_ShouldChangeValuesOnOrderById_WhenOrderExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int orderid = 1;

            _context.User.Add(
            new User
            {
                UserId = 1,
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
            await _context.SaveChangesAsync();


            Orders order = new()
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping"
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            Orders updateOrder = new()
            {
                OrderId = orderid,
                UserId = 1,
                OrderStatus = "Delivered"
            };

            //Act
            var result = await _sut.Update(orderid, updateOrder);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Orders>(result);
            Assert.Equal(orderid, result.OrderId);
            Assert.Equal(updateOrder.OrderId, result.OrderId);
            Assert.Equal(updateOrder.UserId, result.UserId);
            Assert.Equal(updateOrder.OrderStatus, result.OrderStatus);
          

        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenOrderDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int orderid = 1;

            Orders updatedOrder = new()
            {
                OrderId = orderid,
                UserId = 1,
                OrderStatus = "Delivered"
            };

            //Act
            var result = await _sut.Update(orderid, updatedOrder);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async Task Delete_ShouldReturnDeletedOrder_WhenOrderIsDeleted()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int orderid = 1;

            Orders order = new()
            {
                OrderId = 1,
                UserId = 1,
                OrderStatus = "Shipping"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.Delete(orderid);

            var deletedItem = await _sut.GetAllOrders();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Orders>(result);
            Assert.Equal(orderid, result.OrderId);
            Assert.Empty(deletedItem);
        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenOrderDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int orderid = 1;

            //Act
            var result = await _sut.Delete(orderid);

            //Assert
            Assert.Null(result);

        }
    }
}
