using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.Repositories;
using Xunit;

namespace WebshopTest
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

            //Act

            //Assert

        }
        [Fact]
        public async Task GetAllItems_ShouldReturnEmptyList_WhenNoItemsExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task GetItemById_ShouldReturnItemObject_WhenItemExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task GetItemById_ShouldReturnNull_WhenItemDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task Create_ShouldAddIdToItem_WhenSavingDataToDatabase()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task Create_ShouldFail_WhenAddingItemWithExistingId()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task Update_ShouldChangeValuesOnItemById_WhenItemExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenItemDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task Delete_ShouldReturnDeletedItem_WhenItemIsDeleted()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenItemDoesNotExist()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
