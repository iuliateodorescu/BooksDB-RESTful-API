using BooksAPI.Domain;
using BooksAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.UnitTests.Mock
{
    public class UserRepositoryMock : IUserRepository
    {
        List<User> users;
        List<LibraryItem> items;

        public UserRepositoryMock()
        {
            users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    FirstName = "Aaron",
                    LastName = "Smith",
                    EMail = "smith@gmail.com",
                    Username = "smithA",
                    Password = "qwerty",
                    LibraryItems = new List<LibraryItem>
                    {
                        new LibraryItem
                        {
                            LibraryItemId =1,
                            UserId = 1,
                            BookId = 1
                        }
                    }
                }
            };
            items = new List<LibraryItem>
            {
                new LibraryItem
                {
                    LibraryItemId = 1,
                    UserId = 1,
                    BookId = 1
                }
            };
        }
        public async Task<User> AuthenticateUser(string username, string password)
        {
            await Task.Delay(100);
            var user = users.FirstOrDefault(x => x.Username == username);

            if(user == null)
            {
                return null;
            }

            if(user.Password != password)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> CreateUser(User user)
        {
            await Task.Delay(100);
            users.Add(user);
            return true;
        }

        public async Task<User> GetUser(int userId)
        {
            await Task.Delay(100);
            return users.SingleOrDefault(x => x.UserId == userId);
        }

        public async Task<List<LibraryItem>> GetUserLibrary(int userId, int pageStart, int pageSize)
        {
            await Task.Delay(100);
            return items
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.LibraryItemId)
                .Skip(pageStart - 1)
                .Take(pageSize)
                .ToList();
        }

        public async Task<bool> UpdateUserLibrary(int userId, LibraryItem libraryItem)
        {
            await Task.Delay(100);
            var user = await GetUser(userId);
            user.LibraryItems.Add(libraryItem);
            return true;
        }
    }
}
