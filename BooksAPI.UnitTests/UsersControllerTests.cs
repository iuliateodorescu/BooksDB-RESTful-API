using AutoMapper;
using BooksAPI.Controllers;
using BooksAPI.Domain;
using BooksAPI.Domain.Dto;
using BooksAPI.Domain.Mapping;
using BooksAPI.Repository;
using BooksAPI.UnitTests.Mock;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BooksAPI.UnitTests
{
    public class UsersControllerTests
    {
        UsersController controller;
        IUserRepository userRepositoryMock;
        IMapper mapper;

        UserDto validUser;
        LibraryItemDto item;

        public UsersControllerTests()
        {
            userRepositoryMock = new UserRepositoryMock();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new BooksMapping()); });
            mapper = mappingConfig.CreateMapper();

            controller = new UsersController(userRepositoryMock, mapper);

            validUser = new UserDto
            {
                FirstName = "Aaron",
                LastName = "Smith",
                EMail = "smith@gmail.com",
                Username = "smithA",
                Password = "qwerty",
            };
            item = new LibraryItemDto { BookId = 2 };
        }

        [Fact]
        public async Task RegisterUser_IfDatabaseCreateIsSuccessful_ShouldReturnCreated()
        {
            var createdResult = await controller.RegisterUser(validUser);
            
            Assert.IsType<CreatedAtActionResult>(createdResult);
        }

        [Fact]
        public async Task AuthenticateUser_IfCredentialsAreValidAndBelongToUser_ShouldReturnOk()
        {
            var okResult = await controller.AuthenticateUser(validUser.Username, validUser.Password);
            var okResultObject = okResult as OkObjectResult;

            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<UserDto>(okResultObject.Value);
            Assert.Equal(validUser.Username, (okResultObject.Value as UserDto).Username);
        }

        [Fact]
        public async Task AuthenticateUser_IfCredentialsAreValidButDoNotBelongToAnyUser_ShouldReturnNotFound()
        {
            var notFoundResult = await controller.AuthenticateUser("smithA", "password");

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task AuthenticateUser_IfUsernameIsNullOrEmppty_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.AuthenticateUser("", "qwerty");
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task AuthenticateUser_IfPasswordIsNullOrEmppty_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.AuthenticateUser("smithA", "");
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task UpdateUserLibrary_IfUserIdIsValid_ShouldReturnOk()
        {
            var okResult = await controller.UpdateUserLibrary(1, item);

            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public async Task UpdateUserLibrary_IfUserIdIsNotValid_ShouldReturnNotFound()
        {
            var notFoundResult = await controller.UpdateUserLibrary(5, item);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task GetUserLibrary_IfParametersAreValid_ShouldReturnOk()
        {
            var okResult = await controller.GetUserLibrary(1, 1, 5);
            var okResultObject = okResult as OkObjectResult;

            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<List<LibraryItemDto>>(okResultObject.Value);
        }

        [Fact]
        public async Task GetUserLibrary_IfPageStartIsNegative_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetUserLibrary(1, -1, 5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task GetUserLibrary_IfPageSizeIsNegative_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetUserLibrary(1, 1, -5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task GetUserLibrary_IfUserIdIsNotValid_ShouldReturnNotFound()
        {
            var notFoundResult = await controller.GetUserLibrary(10, 1, 5);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
