﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Repositories;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.Item
{
    public class itemServiceTest
    {
        private readonly ItemService _sut;
        private readonly Mock<IItemRepo> _itemRepo = new();

        public itemServiceTest()
        {
            _sut = new ItemService(_itemRepo.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfItemResponse_WhenItemsExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfItemResponse_WhenNoItemExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void GetById_ShouldReturnItemResponse_WhenItemExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenItemDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void Create_ShouldReturnItemResponse_WhenCreateIsSuccessful()
        {
            //Arrange

            //Act

            //Assert

        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedItemResponse_WhenUpdateIsSuccessful()
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
