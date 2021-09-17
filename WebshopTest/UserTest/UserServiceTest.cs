using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI.Repositories;
using WebshopAPI.Services;
using Xunit;

namespace WebshopTest.UserTest
{
    public class UserServiceTest
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepo> _userRepo = new();

        public UserServiceTest()
        {
            _sut = new UserService(_userRepo.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnListOfUsersResponse_WhenUsersExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfUsersResponse_WhenNoUsersExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void GetById_ShouldReturnUserResponse_WhenUserExists()
        {
            //Arrange

            //Act

            //Assert

        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenUserDoesNotExists()
        {
            //Arrange

            //Act

            //Assert

        }


        [Fact]
        public async void Create_ShouldReturnUserResponse_WhenCreateIsSuccessful()
        {
            //Arrange

            //Act

            //Assert

        }

        // Burde der være en her med WhenCreateFailed() ???? 


        [Fact]
        public async void Update_ShouldReturnUpdatedUserResponse_WhenUpdateIsSuccessful()
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
