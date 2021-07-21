using BooksAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);

        Task<User> AuthenticateUser(string username, string password);

        Task<bool> UpdateUserLibrary(int userId, LibraryItem libraryItem);

        Task<User> GetUser(int userId);

        Task<List<LibraryItem>> GetUserLibrary(int userId, int pageStart, int pageSize);
    }
}
