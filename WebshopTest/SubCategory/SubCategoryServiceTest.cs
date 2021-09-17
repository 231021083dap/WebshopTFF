using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Repositories;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.SubCategory
{
    public class SubCategoryServiceTest
    {
        private readonly SubService _sut;
        private readonly Mock<ISubRepo> _subRepo = new();

        public SubCategoryServiceTest()
        {
            _sut = new SubService(_subRepo.Object);

            //Implementering af categoryRepo i subrepo error. 
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfSubCategoryResponse_WhenSubCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfSubCategoryResponse_WhenNoSubCategoriesExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void GetById_ShouldReturnSubCategoryResponse_WhenSubCategoryExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenSubCategoryDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void Create_ShouldReturnSubCategoryResponse_WhenCreateIsSuccessful()
        {
            //Arrange

            //Act

            //Assert

        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedSubCategoryResponse_WhenUpdateIsSuccessful()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenUpdateFailed()
        {
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
