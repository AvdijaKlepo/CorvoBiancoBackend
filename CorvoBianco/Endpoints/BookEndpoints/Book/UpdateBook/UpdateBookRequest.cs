using CorvoBianco.Data.Models;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.UpdateBook
{
    public class UpdateBookRequest
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public int Author { get; set; }
        public int SeriesId { get; set; }
        public float? Rating { get; set; }
        public float? RatingCount { get; set; }
        public string Description { get; set; } = null!;
        public int GenreId { get; set; } 
        public int PageCount { get; set; } = 0;
        public DateTime Published { get; set; }
    }
}
