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

namespace WebshopTest.CategoryTest
{
    public class CategoryRepoTest
    {
        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly CategoryRepo _sut;

        public CategoryRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "WebshopCategory")
                .Options;

            _context = new WebshopContext(_options);

            _sut = new CategoryRepo(_context);
        }

        [Fact]
        public async Task GetAllCategories_ShouldReturnListOfCategories_WhenCategoriesExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Category.Add(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Hardware"
            });
            _context.Category.Add(
            new Category
            {
                CategoryId = 2,
                CategoryName = "Mobile"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetAllCategories();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetAllCategories_ShouldReturnEmptyList_WhenNoCategoriesExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _sut.GetAllCategories();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result);
            Assert.Empty(result);
        }


        [Fact]
        public async Task GetCategoryById_ShouldReturnCategoryObject_WhenCategoryExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int categoryid = 1;

            _context.Category.Add(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Hardware"
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetById(categoryid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(categoryid, result.CategoryId);
        }
        [Fact]
        public async Task GetCategoryById_ShouldReturnNull_WhenCategoryDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int categoryid = 1;

            //Act
            var result = await _sut.GetById(categoryid);

            //Assert
            Assert.Null(result);

        }


    }
}
