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

namespace WebshopTest.Item
{
    public class itemControllerTest
    {
        private readonly ItemController _sut;
        private readonly Mock<IItemService> _itemService = new();

        public itemControllerTest()
        {
            _sut = new ItemController(_itemService.Object);
        }


        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            List<ItemResponse> items = new();
            items.Add(new ItemResponse
            {
                ItemId = 1,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock"
            });

            items.Add(new ItemResponse
            {
                ItemId = 2,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 8,
                ItemStatus = "In Stock"
            });

            _itemService
                .Setup(s => s.GetAllItems())
                .ReturnsAsync(items);

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
            List<ItemResponse> items = new();

            _itemService
                .Setup(s => s.GetAllItems())
                .ReturnsAsync(items);

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
            _itemService
                .Setup(s => s.GetAllItems())
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
            _itemService
                .Setup(s => s.GetAllItems())
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
            int itemid = 1;

            ItemResponse item = new()
            {
                ItemId = itemid,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock"
            };

            _itemService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(item);

            //Act
            var result = await _sut.GetById(itemid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenItemDoesNotExists()
        {
            //Arrange
            int itemid = 1;

            _itemService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(itemid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _itemService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.GetById(1);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);

        }


        [Fact]
        public async void CreateNew_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            //Arrange
            int itemid = 1;

            NewItem newItem = new()
            {
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock"
            };

            ItemResponse item = new()
            {
                ItemId = itemid,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock"
            };

            _itemService
                .Setup(s => s.Create(It.IsAny<NewItem>()))
                .ReturnsAsync(item);

            //Act
            var result = await _sut.Create(newItem);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);


        }
        [Fact]
        public async void CreateNew_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            NewItem newItem = new()
            {
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock"
            };

            _itemService
                .Setup(s => s.Create(It.IsAny<NewItem>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Create(newItem);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            //Arrange
            int itemid = 1;
            UpdateItem updateItem = new()
            {
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 10,
                ItemStatus = "In Stock"
            };

            ItemResponse item = new()
            {
                ItemId = itemid,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock"
            };

            _itemService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateItem>()))
                .ReturnsAsync(item);

            //Act
            var result = await _sut.Update(itemid, updateItem);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int itemid = 1;
            UpdateItem updateItem = new()
            {
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 10,
                ItemStatus = "In Stock"
            };

            _itemService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateItem>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Update(itemid, updateItem);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Delete_ShouldReturnStatusCode200_WhenDataIsDeleted()
        {
            //Arrange
            int itemid = 1;

            _itemService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            //Act
            var result = await _sut.Delete(itemid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int itemid = 1;

            _itemService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));

            //Act
            var result = await _sut.Delete(itemid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);


        }

    }
}
