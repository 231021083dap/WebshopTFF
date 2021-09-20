using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using WebshopAPI.Controllers;
using WebshopAPI.DTO;
using WebshopAPI.Responses;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.SubCategoryTest
{
    public class SubCategoryControllerTest
    {
        private readonly SubController _sut;
        private readonly Mock<ISubService> _subService = new();

        public SubCategoryControllerTest()
        {
            _sut = new SubController(_subService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            //Arrange
            List<SubResponse> sub = new();

            sub.Add(new SubResponse
            {
                SubId = 1,
                SubName = "SmartWatches",
                CategoryId = 5
            });

            sub.Add(new SubResponse
            {
                SubId = 2,
                SubName = "MobilePhones",
                CategoryId = 5
            });

            _subService
                .Setup(s => s.GetAllSubs())
                .ReturnsAsync(sub);

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
            List<SubResponse> sub = new();

            _subService
                .Setup(s => s.GetAllSubs())
                .ReturnsAsync(sub);

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
            _subService
                .Setup(s => s.GetAllSubs())
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
            _subService
                .Setup(s => s.GetAllSubs())
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
            int subid = 1;

            SubResponse sub = new()
            {
                SubId = subid,
                SubName = "SmartWatch",
                CategoryId = 5
            };

            _subService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.GetById(subid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenDataDoesNotExist()
        {
            //Arrange
            int subid = 1;

            _subService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetById(subid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _subService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.GetById(1);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        
        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            //Arrange
            int subid = 1;

            NewSubCategory newsub = new()
            {
                SubName = "SmartWatch",
                CategoryId = 5
            };

            SubResponse sub = new()
            {
                SubId = subid,
                SubName = "SmartWatch",
                CategoryId = 5
            };

            _subService
                .Setup(s => s.Create(It.IsAny<NewSubCategory>()))
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.Create(newsub);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            NewSubCategory newsub = new()
            {
                SubName = "SmartWatch",
                CategoryId = 5
            };

            _subService
                .Setup(s => s.Create(It.IsAny<NewSubCategory>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Create(newsub);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsUpdated()
        {
            //Arrange
            int subid = 1;

            UpdateSubCategory updateSub = new()
            {
                SubName = "SmartWatch",
                CategoryId = 5
            };

            SubResponse sub = new()
            {
                SubId = subid,
                SubName = "SmartWatch",
                CategoryId = 5
            };

            _subService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateSubCategory>()))
                .ReturnsAsync(sub);

            //Act
            var result = await _sut.Update(subid, updateSub);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int subid = 1;

            UpdateSubCategory updateSub = new()
            {
                SubName = "SmartWatch",
                CategoryId = 5
            };

            _subService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateSubCategory>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Update(subid, updateSub);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }


        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenDataIsDeleted()
        {
            //Arrange
            int subid = 1;

            _subService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            //Act
            var result = await _sut.Delete(subid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int subid = 1;

            _subService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an Exception"));

            //Act
            var result = await _sut.Delete(subid);

            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }

    }
}
