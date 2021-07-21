using AutoMapper;
using BooksAPI.Domain;
using BooksAPI.Domain.Dto;
using BooksAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Registers an user
        /// </summary>
        /// <param name="userDto">The user dto object</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            var saved = await userRepository.CreateUser(user);

            if (!saved)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return CreatedAtAction(nameof(AuthenticateUser), new { username = user.Username, password = user.Password}, userDto);
        }

        /// <summary>
        /// Authenticates an user
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        [HttpGet("{username}/{password}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<IActionResult> AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid parameters");
            }

            var user = await userRepository.AuthenticateUser(username,password);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        /// <summary>
        /// Updates the library of the user
        /// </summary>
        /// <param name="userId">The Id of the user</param>
        /// <param name="libraryItemDto">The library item dto object</param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserLibrary(int userId, [FromBody] LibraryItemDto libraryItemDto)
        {
            if (await userRepository.GetUser(userId) == null)
            {
                return NotFound();
            }

            var libraryItem = mapper.Map<LibraryItem>(libraryItemDto);
            var updated = await userRepository.UpdateUserLibrary(userId, libraryItem);

            if (!updated)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok();
        }

        /// <summary>
        /// Returns the items from the user's library
        /// </summary>
        /// <param name="userId">The Id of the user</param>
        /// <param name="pageStart">The page start position (>0)</param>
        /// <param name="pageSize">The page size (>0)</param>
        /// <returns></returns>
        [HttpGet("{userId}/{pageStart}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LibraryItemDto>))]
        public async Task<IActionResult> GetUserLibrary(int userId, int pageStart, int pageSize)
        {
            if (pageStart <= 0 || pageSize <= 0)
            {
                return BadRequest("Invalid parameters");
            }

            if(await userRepository.GetUser(userId) == null)
            {
                return NotFound();
            }

            var items = await userRepository.GetUserLibrary(userId, pageStart, pageSize);
            var itemDtos = items.Select(item => mapper.Map<LibraryItemDto>(item)).ToList();
            return Ok(itemDtos);
        }

    }
}
