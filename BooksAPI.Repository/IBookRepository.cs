using BooksAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks(int pageStart, int pageSize);

        Task<Book> GetBook(int bookId);

        Task<List<Book>> GetBooksByTitle(string text, int pageStart, int pageSize);

        Task<bool> DeleteBook(Book book);
        Task<List<Book>> GetRecommendations(string title);
    }
}
