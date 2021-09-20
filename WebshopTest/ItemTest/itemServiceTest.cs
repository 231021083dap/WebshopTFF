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

namespace WebshopTest.ItemTest
{
    public class itemServiceTest
    {
        private readonly ItemService _sut;
        private readonly Mock<IItemRepo> _itemRepo = new();
        private readonly Mock<ISubRepo> _subRepo = new();

        public itemServiceTest()
        {
            _sut = new ItemService(_itemRepo.Object, _subRepo.Object);
            
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfItemResponse_WhenItemsExists()
        {
            //Arrange
            List<Item> item = new List<Item>();

            item.Add(new Item
            {
                ItemId = 1,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 20,
                ItemStatus = "In Stock",
                SubCategory = new()
                {
                    SubId = 1,
                    SubName = "test",
                    CategoryId = 1
                }
            });

            item.Add(new Item
            {
                ItemId = 2,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock",
                SubCategory = new()
                {
                    SubId = 1,
                    SubName = "test",
                    CategoryId = 1
                }
            });

            _itemRepo
                .Setup(s => s.GetAllItems())
                .ReturnsAsync(item);

            //Act
            var result = await _sut.GetAllItems();


            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<ItemResponse>>(result);
        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfItemResponse_WhenNoItemExists()
        {
            //Arrange
            List<Item> item = new List<Item>();

            _itemRepo
                .Setup(s => s.GetAllItems())
                .ReturnsAsync(item);


            //Act
            var result = await _sut.GetAllItems();


            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<ItemResponse>>(result);

        }


        [Fact]
        public async void GetById_ShouldReturnItemResponse_WhenItemExists()
        {
            //Arrange
            int itemid = 1;

            Item item = new()
            {
                ItemId = itemid,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock",
                SubCategory = new()
                {
                    SubId = 1,
                    SubName = "test",
                    CategoryId = 1
                }
            };

            _itemRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(item);

            //Act
            var result = await _sut.GetById(itemid);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<ItemResponse>(result);
            Assert.Equal(item.ItemId, result.ItemId);
            Assert.Equal(item.ItemName, result.ItemName);
            Assert.Equal(item.SubCategoryId, result.SubCategoryId);
            Assert.Equal(item.ItemPrice, result.ItemPrice);
            Assert.Equal(item.ItemDiscount, result.ItemDiscount);
            Assert.Equal(item.ItemAmount, result.ItemAmount);
            Assert.Equal(item.ItemStatus, result.ItemStatus);
        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenItemDoesNotExists()
        {
            //Arrange
            int itemid = 1;

            _itemRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(itemid);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public async void Create_ShouldReturnItemResponse_WhenCreateIsSuccessful()
        {
            //Arrange
            NewItem newItem = new()
            {
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            int itemid = 1;

            Item item = new()
            {
                ItemId = itemid,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            _itemRepo
                .Setup(s => s.Create(It.IsAny<Item>()))
                .ReturnsAsync(item);

            SubCategory sub = new()
            {
                SubId = 1,
                SubName = "test",
                CategoryId = 1
            };

            _subRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(sub);


            //Act
            var result = await _sut.Create(newItem);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ItemResponse>(result);
            Assert.Equal(itemid, result.ItemId); 
            Assert.Equal(newItem.ItemName, result.ItemName);
            Assert.Equal(newItem.SubCategoryId, result.SubCategoryId);
            Assert.Equal(newItem.ItemPrice, result.ItemPrice);
            Assert.Equal(newItem.ItemDiscount, result.ItemDiscount);
            Assert.Equal(newItem.ItemAmount, result.ItemAmount);
            Assert.Equal(newItem.ItemStatus, result.ItemStatus);

        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedItemResponse_WhenUpdateIsSuccessful()
        {
            //Arrange
            UpdateItem updateItem = new()
            {
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            int itemid = 1;

            Item item = new()
            {
                ItemId = itemid,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            _itemRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Item>()))
                .ReturnsAsync(item);

            SubCategory sub = new()
            {
                SubId = 1,
                SubName = "test",
                CategoryId = 1
            };

            _subRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(sub);


            //Act
            var result = await _sut.Update(itemid, updateItem);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ItemResponse>(result);
            Assert.Equal(itemid, result.ItemId);
            Assert.Equal(updateItem.ItemName, result.ItemName);
            Assert.Equal(updateItem.SubCategoryId, result.SubCategoryId);
            Assert.Equal(updateItem.ItemPrice, result.ItemPrice);
            Assert.Equal(updateItem.ItemDiscount, result.ItemDiscount);
            Assert.Equal(updateItem.ItemAmount, result.ItemAmount);
            Assert.Equal(updateItem.ItemStatus, result.ItemStatus);

        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenUpdateFailed()
        {
            //Arrange
            UpdateItem updateItem = new()
            {
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            int itemid = 1;

            _itemRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Item>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.Update(itemid, updateItem);

            //Assert
            Assert.Null(result);

        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            //Arrange
            int itemid = 1;

            Item item = new()
            {
                ItemId = itemid,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            _itemRepo
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(item);

            //Act
            var result = await _sut.Delete(itemid);

            //Assert
            Assert.True(result);
        }

    }
}
