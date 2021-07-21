using BooksAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext context;

        public BookRepository(BooksDbContext context)
        {
            this.context = context;
        }

        public async Task<Book> GetBook(int bookId)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.BookId == bookId);
        }

        public async Task<List<Book>> GetBooks(int pageStart, int pageSize)
        {
            return await context.Books
                .OrderBy(x => x.BookId)
                .Skip(pageStart - 1)
                .Take(pageSize).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByTitle(string text, int pageStart, int pageSize)
        {
            return await context.Books
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .OrderBy(x => x.BookId)
                .Skip(pageStart-1)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> DeleteBook(Book book)
        {
            var result = 0;

            try
            {
                context.Remove(book);
                result = await context.SaveChangesAsync();
            }
            catch
            {

            }
            return result > 0;
        }

        public async Task<List<Book>> GetRecommendations(string title)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Python39\python.exe";

            var script = @"my_script.py";

            psi.Arguments = $"\"{script}\" \"{title}\"";

            psi.WorkingDirectory = @"E:\Licenta\Recommendations";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            var bookTitles = results.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<Book> books = new List<Book>();

            foreach ( string t in bookTitles)
            {
                var book = await context.Books.FirstOrDefaultAsync(x => x.Title == t);
                if(book != null)
                {
                    books.Add(book);
                }
            }

            return books;
        }
    }
}
