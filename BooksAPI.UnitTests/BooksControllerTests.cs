using AutoMapper;
using BooksAPI.Controllers;
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
    public class BooksControllerTests
    {
        BooksController controller;
        IBookRepository bookRepositoryMock;
        IMapper mapper;

        public BooksControllerTests()
        {
            bookRepositoryMock = new BookRepositoryMock();

            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new BooksMapping()); });
            mapper = mappingConfig.CreateMapper();

            controller = new BooksController(bookRepositoryMock, mapper);
        }

        [Fact]
        public async Task GetBook_IfBookIdIsValid_ShouldReturnOk()
        {
            var okResult = await controller.GetBook(1);
            var okResultObject = okResult as OkObjectResult;

            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<BookDto>(okResultObject.Value);
            Assert.Equal("Oliver Twist", (okResultObject.Value as BookDto).Title);
        }

        [Fact]
        public async Task GetBook_IfBookIdIsNotValid_ShouldReturnNotFound()
        {
            var notFoundResult = await controller.GetBook(10);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task GetBooks_IfParametersArePositive_ShouldReturnOk()
        {
            var okResult = await controller.GetBooks(1, 5);
            var okResultObject = okResult as OkObjectResult;

            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<List<BookSummaryDto>>(okResultObject.Value);
        }

        [Fact]
        public async Task GetBooks_IfPageStartIsNegative_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetBooks(-4, 5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task GetBooks_IfPageSizeIsNegative_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetBooks(1, -5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task GetBooksByTitle_IfParametersAreValidAndBookTitlesContainText_ShouldReturnOk()
        {
            var okResult = await controller.GetBooksByTitle("oliver", 1, 5);
            var okResultObject = okResult as OkObjectResult;

            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<List<BookSummaryDto>>(okResultObject.Value);
        }

        [Fact]
        public async Task GetBooksByTitle_IfParametersAreValidAndNoBookTitleContainsText_ShouldReturnNotFound()
        {
            var notFoundResult = await controller.GetBooksByTitle("qwerty", 1, 5);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task GetBooksByTitle_IfTextIsEmptyOrWhiteSpace_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetBooksByTitle("", 1, 5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task GetBooksByTitle_IfPageStartIsNegative_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetBooksByTitle("oliver", -1, 5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }

        [Fact]
        public async Task GetBooksByTitle_IfPageSizeIsNegative_ShouldReturnBadRequest()
        {
            var badRequestResult = await controller.GetBooksByTitle("oliver", 1, -5);
            var badRequestResultObject = badRequestResult as BadRequestObjectResult;

            Assert.IsType<BadRequestObjectResult>(badRequestResult);
            Assert.IsType<string>(badRequestResultObject.Value);
        }
    }
}
