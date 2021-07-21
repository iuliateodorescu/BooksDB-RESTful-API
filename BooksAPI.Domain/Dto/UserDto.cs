using System.Collections.Generic;

namespace BooksAPI.Domain.Dto
{
    public class UserDto
    {
        public UserDto()
        {
            LibraryItemsDto = new List<LibraryItemDto>();
        }

        public ICollection<LibraryItemDto> LibraryItemsDto { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string EMail { get; set; }

        public string Password { get; set; }
    }
}
