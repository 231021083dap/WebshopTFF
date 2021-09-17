using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB;
using WebshopAPI.Repositories;
using Xunit;

namespace WebshopTest.Category
{
    public class CategoryRepoTest
    {
        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly CategoryRepo _sut;

        public CategoryRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "Webshop")
                .Options;

            _context = new WebshopContext(_options);

            _sut = new CategoryRepo(_context);
        }

        [Fact]
        public async Task GetAllCategories_ShouldReturnListOfCategories_WhenCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task GetAllCategories_ShouldReturnEmptyList_WhenNoCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async Task GetCategoryById_ShouldReturnCategoryObject_WhenCategoryExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async Task GetCategoryById_ShouldReturnNull_WhenCategoryDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


    }
}
