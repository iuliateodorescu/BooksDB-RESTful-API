namespace BooksAPI.Domain
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int EditionYear { get; set; }

        public string Publisher { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
