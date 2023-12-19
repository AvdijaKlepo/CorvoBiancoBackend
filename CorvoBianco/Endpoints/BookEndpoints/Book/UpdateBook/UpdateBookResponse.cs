namespace CorvoBianco.Endpoints.BookEndpoints.Book.UpdateBook
{
    public class UpdateBookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Series { get; set; }
        public float? Rating { get; set; }
        public float? RatingCount { get; set; }
    }
}
