using BooksAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BooksDbContext context;

        public UserRepository(BooksDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            var result = 0;

            try
            {
                context.Add(user); //buffer, nu s-a adaugat propriu-zis
                result = await context.SaveChangesAsync(); //aici se adauga
            }
            catch
            {
                //ignored
            }
            return result > 0;
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            if (user.Password != password)
            { 
                return null;
            }

            return user;
        }

        public async Task<bool> UpdateUserLibrary(int userId, LibraryItem libraryItem)
        {
            var result = 0;

            try
            {
                var user = await GetUser(userId);
                var item = await context.LibraryItems.FirstOrDefaultAsync(x => (x.UserId == userId) && (x.BookId == libraryItem.BookId));
                if(item != null)
                {
                    return result > 0;
                }

                user.LibraryItems.Add(libraryItem);
                result = await context.SaveChangesAsync();
            }
            catch
            {
                //ignored
            }

            return result>0;
        }

        public async Task<User> GetUser(int userId)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<LibraryItem>> GetUserLibrary(int userId, int pageStart, int pageSize)
        {
            return await context.LibraryItems
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.LibraryItemId)
                .Skip(pageStart - 1)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
