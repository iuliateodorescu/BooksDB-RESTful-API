namespace BooksAPI.Domain.Dto
{
    public class BookSummaryDto
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }
    }
}
