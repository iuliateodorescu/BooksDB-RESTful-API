using System.Collections.Generic;

namespace BooksAPI.Domain
{
    public class User
    {
        public User()
        {
            LibraryItems = new List<LibraryItem>();
        }

        public int UserId { get; set; }

        public ICollection<LibraryItem> LibraryItems { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string EMail { get; set; }

        public string Password { get; set; }


    }
}
