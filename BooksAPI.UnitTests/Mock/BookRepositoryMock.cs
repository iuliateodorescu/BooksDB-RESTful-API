using BooksAPI.Domain;
using BooksAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.UnitTests.Mock
{
    public class BookRepositoryMock : IBookRepository
    {
        List<Book> books;

        public BookRepositoryMock()
        {
            books = new List<Book>
            {
                new Book
                {
                    BookId = 1,
                    Title = "Oliver Twist",
                    Author = "Charles Dickens",
                    ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141198880.jpg",
                    EditionYear = 2012,
                    Publisher = "Penguin Books",
                    Description = "'A parish child - the orphan of a workhouse - the humble, half-starved drudge - to be cuffed and buffeted through the world, despised by all, and pitied by none'Dark, mysterious and mordantly funny, Oliver Twist features some of the most memorably drawn villains in all of fiction - the treacherous gangmaster Fagin, the menacing thug Bill Sikes, the Artful Dodger and their den of thieves in the grimy London backstreets. Dicken's novel is both an angry indictment of poverty, and an adventure filled with an air of threat and pervasive evil."
                },
                new Book
                {
                    BookId = 2, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde",
                    ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141199498.jpg",
                    EditionYear = 2012, Publisher = "Penguin Books",
                    Description = "'I am jealous of everything whose beauty does not die. I am jealous of the portrait you have painted of me ... Why did you paint it? It will mock me some day - mock me horribly!'A story of evil, debauchery and scandal, Oscar Wilde's only novel tells of Dorian Gray, a beautiful yet corrupt man. When he wishes that a perfect portrait of himself would bear the signs of ageing in his place, the picture becomes his hideous secret, as it follows Dorian's own downward spiral into cruelty and depravity. The Picture of Dorian Gray is a masterpiece of the evil in men's hearts, and is as controversial and alluring as Wilde himself."
                }};
        }
        public async Task<Book> GetBook(int bookId)
        {
            await Task.Delay(100);
            return books.FirstOrDefault(x => x.BookId == bookId);
        }

        public async Task<List<Book>> GetBooks(int pageStart, int pageSize)
        {
            await Task.Delay(100);
            return books
                .OrderBy(x => x.BookId)
                .Skip(pageStart - 1)
                .Take(pageSize)
                .ToList();
        }

        public async Task<List<Book>> GetBooksByTitle(string text, int pageStart, int pageSize)
        {
            await Task.Delay(100);
            return books
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .OrderBy(x => x.BookId)
                .Skip(pageStart - 1)
                .Take(pageSize)
                .ToList();
        }

        public async Task<bool> DeleteBook(Book book)
        {
            await Task.Delay(100);
            books.Remove(book);
            return true;
        }

        public Task<List<Book>> GetRecommendations(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
