using AutoMapper;
using BooksAPI.Domain.Dto;
using BooksAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns all the information of a book
        /// </summary>
        /// <param name="bookId">The book Id</param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await bookRepository.GetBook(bookId);
            if(book == null)
            {
                return NotFound();
            }

            var bookDto = mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        /// <summary>
        /// Returns a page of books
        /// </summary>
        /// <param name="pageStart">The page start position (>0)</param>
        /// <param name="pageSize">The page size (>0)</param>
        /// <returns></returns>
        [HttpGet("{pageStart}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookSummaryDto>))]
        public async Task<IActionResult> GetBooks(int pageStart, int pageSize)
        {
            if(pageStart <= 0 || pageSize <= 0)
            {
                return BadRequest("Invalid parameters");
            }

            var books = await bookRepository.GetBooks(pageStart, pageSize);
            var bookSummaries = books.Select(book => mapper.Map<BookSummaryDto>(book)).ToList();

            return Ok(bookSummaries);
        }

        /// <summary>
        /// Returns the books that contain the string text in their title
        /// </summary>
        /// <param name="text">The text which the title should contain</param>
        /// <param name="pageStart">The page start position (>0)</param>
        /// <param name="pageSize">The page size (>0)</param>
        /// <returns></returns>
        [HttpGet("{text}/{pageStart}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookSummaryDto>))]
        public async Task<IActionResult> GetBooksByTitle(string text, int pageStart, int pageSize)
        {
            if(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Invalid parameter");
            }

            if(pageStart <= 0 || pageSize <= 0)
            {
                return BadRequest("Invalid parameters");
            }

            var books = await bookRepository.GetBooksByTitle(text, pageStart, pageSize);
            if (!books.Any())
            {
                return NotFound();
            }

            var bookSummaries = books.Select(book => mapper.Map<BookSummaryDto>(book)).ToList();

            return Ok(bookSummaries);
        }

        /// <summary>
        /// Gets the recommendations
        /// </summary>
        /// <param name="title">The title of the reference book</param>
        /// <returns></returns>
        [HttpGet("getRecommendations/{title}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookSummaryDto>))]
        public async Task<IActionResult> GetRecommendations(string title)
        {
            var books = await bookRepository.GetRecommendations(title);

            if (!books.Any())
            {
                return NotFound();
            }

            var bookSummaries = books.Select(book => mapper.Map<BookSummaryDto>(book)).ToList();

            return Ok(bookSummaries);
        }
    }
}
