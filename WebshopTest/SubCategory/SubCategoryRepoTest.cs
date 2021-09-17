using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.Repositories;
using Xunit;

namespace WebshopTest.SubCategory
{
    public class SubCategoryRepoTest
    {
        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly SubRepo _sut;

        public SubCategoryRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "Webshop")
                .Options;

            _context = new WebshopContext(_options);

            _sut = new SubRepo(_context);
        }

        [Fact]
        public async Task GetAllSubCategories_ShouldReturnListOfSubCategories_WhenSubCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task GetAllSubCategories_ShouldReturnEmptyList_WhenNoSubCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task GetSubCategoryById_ShouldReturnSubCategoryObject_WhenSubCategoryExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task GetSubCategoryById_ShouldReturnNull_WhenSubCategoryDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task Create_ShouldAddIdToSubCategory_WhenSavingDataToDatabase()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task Create_ShouldFail_WhenAddingSubCategoryWithExistingId()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task Update_ShouldChangeValuesOnSubCategoryById_WhenSubCategoryExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenSubCategoryDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task Delete_ShouldReturnDeletedSubCategory_WhenSubCategoryIsDeleted()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenSubCategoryDoesNotExist()
        {
            //Arrange

            //Act

            //Assert

        }


    }
}
