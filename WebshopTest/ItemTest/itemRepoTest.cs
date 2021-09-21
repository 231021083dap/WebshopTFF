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

namespace WebshopTest.ItemTest
{
    public class itemRepoTest
    {
        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly ItemRepo _sut;

        public itemRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "Webshop")
                .Options;

            _context = new WebshopContext(_options);

            _sut = new ItemRepo(_context);
        }

        [Fact]
        public async Task GetAllItems_ShouldReturnListOfItems_WhenItemsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Item.Add(
            new Item
            {
                ItemId = 1,
                ItemName = "MSI Laptop",
                SubCategoryId = 1,
                ItemPrice = 5999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            });

            _context.Item.Add(
            new Item
            {
                ItemId = 2,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetAllItems();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Item>>(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetAllItems_ShouldReturnEmptyList_WhenNoItemsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _sut.GetAllItems();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Item>>(result);
            Assert.Empty(result);
        }


        [Fact]
        public async Task GetItemById_ShouldReturnItemObject_WhenItemExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int itemid = 1;

            _context.Item.Add(
            new Item
            {
                ItemId = 1,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetById(itemid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Item>(result);
            Assert.Equal(itemid, result.ItemId);

        }
        [Fact]
        public async Task GetItemById_ShouldReturnNull_WhenItemDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int itemid = 1;


            //Act
            var result = await _sut.GetById(itemid);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task Create_ShouldAddIdToItem_WhenSavingDataToDatabase()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int hopefullythisId = 1;

            Item item = new()
            {
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            //Act
            var result = await _sut.Create(item);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Item>(result);
            Assert.Equal(hopefullythisId, result.ItemId);

        }
        [Fact]
        public async Task Create_ShouldFail_WhenAddingItemWithExistingId()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            Item item = new()
            {
                ItemId = 1,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            //Act
            Func<Task> action = async () => await _sut.Create(item);

            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }


        [Fact]
        public async Task Update_ShouldChangeValuesOnItemById_WhenItemExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            //Act

            //Assert

        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenItemDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int itemid = 1;

            Item updatedItem = new()
            {

            };
            //Act

            //Assert

        }


        [Fact]
        public async Task Delete_ShouldReturnDeletedItem_WhenItemIsDeleted()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int itemid = 1;

            Item item = new()
            {
                ItemId = 1,
                ItemName = "Acer Laptop",
                SubCategoryId = 1,
                ItemPrice = 2999,
                ItemDiscount = 0,
                ItemAmount = 5,
                ItemStatus = "In Stock"
            };

            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.Delete(itemid);

            var deletedItem = await _sut.GetAllItems();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Item>(result);
            Assert.Equal(itemid, result.ItemId);
            Assert.Empty(deletedItem);

        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenItemDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int itemid = 1;

            //Act
            var result = await _sut.Delete(itemid);

            //Assert
            Assert.Null(result);
        }
    }
}
