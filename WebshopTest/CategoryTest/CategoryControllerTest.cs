using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Controllers;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.CategoryTest
{
    public class CategoryControllerTest
    {
        private readonly CategoryController _sut;
        private readonly Mock<ICategoryService> _categoryService = new();

        public CategoryControllerTest()
        {
            _sut = new CategoryController(_categoryService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            List<CategoryResponse> categories = new();
            categories.Add(new CategoryResponse
            {
                CategoryId = 1,
                CategoryName = "Hardware"
            });

            categories.Add(new CategoryResponse
            {
                CategoryId = 2,
                CategoryName = "Mobile"
            });

            _categoryService
                .Setup(s => s.GetAllCategories())
                .ReturnsAsync(categories);

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
            List<CategoryResponse> categories = new();

            _categoryService
                .Setup(s => s.GetAllCategories())
                .ReturnsAsync(categories);

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
            _categoryService
                .Setup(s => s.GetAllCategories())
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
            _categoryService
                .Setup(s => s.GetAllCategories())
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

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
            int categoryid = 1;

            CategoryResponse category = new()
            {
                CategoryId = categoryid,
                CategoryName = "Hardware"
            };

            _categoryService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(category);

            //Act
            var result = await _sut.GetById(categoryid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenDataDoesNotExist()
        {
            //Arrange
            int categoryid = 1;

            _categoryService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(categoryid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(404, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _categoryService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.GetById(1);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
