using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;
using WebshopAPI.DTO;
using WebshopAPI.Repositories;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.SubCategoryTest
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
            List<SubCategory> sub = new List<SubCategory>();

            sub.Add(new SubCategory
            {
                SubId = 1,
                SubName = "SmartWatches",
                CategoryId = 5
            });

            sub.Add(new SubCategory
            {
                SubId = 2,
                SubName = "MobilePhones",
                CategoryId = 5
            });

            _subRepo
                .Setup(s => s.GetAllSubs())
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.GetAllSubs();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<SubResponse>>(result);

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfSubCategoryResponse_WhenNoSubCategoriesExists()
        {
            //Arrange
            List<SubCategory> sub = new List<SubCategory>();

            _subRepo
                .Setup(s => s.GetAllSubs())
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.GetAllSubs();

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<SubResponse>>(result);
        }


        [Fact]
        public async void GetById_ShouldReturnSubCategoryResponse_WhenSubCategoryExists()
        {
            //Arrange
            int subid = 1;

            SubCategory sub = new()
            {
                SubId = subid,
                SubName = "MobilePhones",
                CategoryId = 5
            };

            _subRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.GetById(subid);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubResponse>(result);
            Assert.Equal(sub.SubId, result.SubId);
            Assert.Equal(sub.SubName, result.SubName);
            Assert.Equal(sub.CategoryId, result.CategoryId);
        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenSubCategoryDoesNotExists()
        {
            //Arrange
            int subid = 1;

            _subRepo
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(subid);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public async void Create_ShouldReturnSubCategoryResponse_WhenCreateIsSuccessful()
        {
            //Arrange
            NewSubCategory newSub = new()
            {
                SubName = "MobilePhones",
                CategoryId = 5
            };

            int subid = 1;

            SubCategory sub = new()
            {
                SubId = subid,
                SubName = "SmartWatches",
                CategoryId = 5
            };

            _subRepo
                .Setup(s => s.Create(It.IsAny<SubCategory>()))
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.Create(newSub);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubResponse>(result);
            Assert.Equal(subid, result.SubId);
            Assert.Equal(newSub.SubName, result.SubName);
            Assert.Equal(newSub.CategoryId, result.CategoryId);
        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedSubCategoryResponse_WhenUpdateIsSuccessful()
        {
            //Arrange
            UpdateSubCategory updateSub = new()
            {
                SubName = "SmartWatches",
                CategoryId = 5
            };

            int subid = 1;

            SubCategory sub = new()
            {
                SubId = subid,
                SubName = "MobilePhones",
                CategoryId = 5
            };

            _subRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<SubCategory>()))
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.Update(subid, updateSub);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<SubResponse>(result);
            Assert.Equal(subid, result.SubId);
            Assert.Equal(updateSub.SubName, result.SubName);
            Assert.Equal(updateSub.CategoryId, result.CategoryId);
        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenUpdateFailed()
        {
            //Arrange
            UpdateSubCategory updateSub = new()
            {
                SubName = "SmartWatches",
                CategoryId = 5
            };

            int subid = 1;

            _subRepo
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<SubCategory>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.Update(subid, updateSub);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            //Arrange
            int subid = 1;

            SubCategory sub = new()
            {
                SubId = subid,
                SubName = "MobilePhones",
                CategoryId = 5
            };

            _subRepo
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(sub);


            //Act
            var result = await _sut.Delete(subid);

            //Assert
            Assert.True(result);
        }
    }
}
