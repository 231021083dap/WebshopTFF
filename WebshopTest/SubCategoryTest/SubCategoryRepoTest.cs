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

namespace WebshopTest.SubCategoryTest
{
    public class SubCategoryRepoTest
    {
        private readonly DbContextOptions<WebshopContext> _options;
        private readonly WebshopContext _context;
        private readonly SubRepo _sut;

        public SubCategoryRepoTest()
        {
            _options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase(databaseName: "WebshopSubCategory")
                .Options;

            _context = new WebshopContext(_options);

            _sut = new SubRepo(_context);
        }

        [Fact]
        public async Task GetAllSubCategories_ShouldReturnListOfSubCategories_WhenSubCategoriesExists()
        {
            //Arrange

            await _context.Database.EnsureDeletedAsync();

            _context.Category.Add(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Test"
            });
            await _context.SaveChangesAsync();

            _context.SubCategory.Add(
            new SubCategory
            {
                SubId = 1,
                SubName = "test",
                CategoryId = 1
            });
            _context.SubCategory.Add(
            new SubCategory
            {
                SubId = 2,
                SubName = "testtest",
                CategoryId = 1
            });

            await _context.SaveChangesAsync();


            //Act
            var result = await _sut.GetAllSubs();


            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<SubCategory>>(result);
            Assert.Equal(2, result.Count);

        }
        [Fact]
        public async Task GetAllSubCategories_ShouldReturnEmptyList_WhenNoSubCategoriesExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();


            //Act
            var result = await _sut.GetAllSubs();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<SubCategory>>(result);
            Assert.Empty(result);
        }


        [Fact]
        public async Task GetSubCategoryById_ShouldReturnSubCategoryObject_WhenSubCategoryExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int subid = 1;

            _context.Category.Add(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Test"
            });
            await _context.SaveChangesAsync();

            _context.SubCategory.Add(
            new SubCategory
            {
                SubId = 1,
                SubName = "test",
                CategoryId = 1
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.GetById(subid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubCategory>(result);
            Assert.Equal(subid, result.SubId);
        }
        [Fact]
        public async Task GetSubCategoryById_ShouldReturnNull_WhenSubCategoryDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int subid = 1;

            //Act
            var result = await _sut.GetById(subid);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async Task Create_ShouldAddIdToSubCategory_WhenSavingDataToDatabase()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int generatedid = 1;

            SubCategory sub = new()
            {
                SubName = "test",
                CategoryId = 1
            };

            //await _context.SaveChangesAsync();

            //Act
            var result = await _sut.Create(sub);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubCategory>(result);
            Assert.Equal(generatedid, result.SubId);

        }
        [Fact]
        public async Task Create_ShouldFail_WhenAddingSubCategoryWithExistingId()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            SubCategory sub = new()
            {
                SubName = "test",
                CategoryId = 1
            };

            _context.SubCategory.Add(sub);
            await _context.SaveChangesAsync();

            //Act
            Func<Task> action = async () => await _sut.Create(sub);

            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }


        [Fact]
        public async Task Update_ShouldChangeValuesOnSubCategoryById_WhenSubCategoryExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int subid = 1;

            SubCategory sub = new()
            {
                SubName = "test",
                CategoryId = 1
            };
            _context.SubCategory.Add(sub);
            await _context.SaveChangesAsync();

            SubCategory updatedsub = new()
            {
                SubId = subid,
                SubName = "UpdatedName",
                CategoryId = 1
            };

            //Act
            var result = await _sut.Update(subid, updatedsub);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubCategory>(result);
            Assert.Equal(subid, result.SubId);
            Assert.Equal(updatedsub.SubName, result.SubName);
            Assert.Equal(updatedsub.CategoryId, result.CategoryId);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenSubCategoryDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int subid = 1;

            SubCategory updatedsub = new()
            {
                SubId = subid,
                SubName = "UpdatedName",
                CategoryId = 1
            };

            //Act
            var result = await _sut.Update(subid, updatedsub);

            //Assert
            Assert.Null(result);

        }


        [Fact]
        public async Task Delete_ShouldReturnDeletedSubCategory_WhenSubCategoryIsDeleted()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int subid = 1;

            SubCategory sub = new()
            {
                SubId = 1,
                SubName = "Test",
                CategoryId = 1
            };

            _context.SubCategory.Add(sub);
            await _context.SaveChangesAsync();

            //Act
            var result = await _sut.Delete(subid);
            var deletedSub = await _sut.GetAllSubs();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubCategory>(result);
            Assert.Equal(subid, result.SubId);
            Assert.Empty(deletedSub);
        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenSubCategoryDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int subid = 1;

            //Act
            var result = await _sut.Delete(subid);

            //Assert
            Assert.Null(result);
        }


    }
}
