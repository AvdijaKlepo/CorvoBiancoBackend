namespace CorvoBianco.Endpoints.BookEndpoints.Book.AddBookCover
{
    public class AddBookCoverRequest
    {
        public int BookId { get; set; }
        public IFormFile? BookCover { get; set; }
    }
}
