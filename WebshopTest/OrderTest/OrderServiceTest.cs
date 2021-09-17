using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Repositories;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.OrderTest
{
    public class OrderServiceTest
    {
        private readonly OrdersService _sut;
        private readonly Mock<IOrdersRepo> _orderRepo = new();

        public OrderServiceTest()
        {
            _sut = new OrdersService(_orderRepo.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfOrdersResponse_WhenOrdersExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfOrdersResponse_WhenNoOrdersExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void GetById_ShouldReturnOrderResponse_WhenOrderExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenOrderDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void Create_ShouldReturnOrderResponse_WhenCreateIsSuccessful()
        {
            //Arrange

            //Act

            //Assert

        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedOrderResponse_WhenUpdateIsSuccessful()
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
