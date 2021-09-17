using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;
using WebshopAPI.Repositories;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.CategoryTest
{
    public class CategoryServiceTest
    {
        private readonly CategoryService _sut;
        private readonly Mock<ICategoryRepo> _categoryRepo = new();

        public CategoryServiceTest()
        {
            _sut = new CategoryService(_categoryRepo.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfCategoryResponse_WhenCategoriesExists()
        {
            //Arrange
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                CategoryId = 1,
                CategoryName = "Hardware"
            });
            categories.Add(new Category
            {
                CategoryId = 2,
                CategoryName = "Mobile"
            });

            _categoryRepo
                .Setup(s => s.GetAllCategories())
                .ReturnsAsync(categories);

            //Act
            var result = await _sut.GetAllCategories();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<CategoryResponse>>(result);

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfCategoryResponse_WhenNoCategoriesExists()
        {
            //Arrange
            List<Category> categories = new List<Category>();

            _categoryRepo
                .Setup(s => s.GetAllCategories())
                .ReturnsAsync(categories);


            //Act
            var result = await _sut.GetAllCategories();

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<CategoryResponse>>(result);

        }


        [Fact]
        public async void GetById_ShouldReturnCategoryResponse_WhenCategoryExists()
        {
            //Arrange
            int catid = 1;

            Category category = new()
            {
                CategoryId = catid,
                CategoryName = "Hardware"
            };

            _categoryRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(category);

            //Act
            var result = await _sut.GetById(catid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(category.CategoryId, result.CategoryId);
            Assert.Equal(category.CategoryName, result.CategoryName);
        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenCategoryDoesNotExists()
        {
            //Arrange
            int catid = 1;

            _categoryRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(catid);


            //Assert
            Assert.Null(result);
        }

    }
}
