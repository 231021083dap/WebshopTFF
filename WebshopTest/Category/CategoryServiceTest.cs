using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Repositories;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.Category
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

            //Act

            //Assert

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfCategoryResponse_WhenNoCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void GetById_ShouldReturnCategoryResponse_WhenCategoryExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenCategoryDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }

    }
}
