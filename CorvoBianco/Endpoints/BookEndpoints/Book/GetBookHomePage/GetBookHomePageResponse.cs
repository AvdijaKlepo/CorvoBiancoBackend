using System.ComponentModel.DataAnnotations;
using CorvoBianco.Data.Models;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.GetBookHomePage
{
    public class GetBookHomePageResponse
    {
        public List<BookGetBookHomePageResponse> Books { get; set; } = null!;
    }
}

public class BookGetBookHomePageResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } 
    public string? Series { get; set; } = "N/A";
    public float? Rating { get; set; } = 0;
    public float? RatingCount { get; set; } = 0;
    public string BookCover { get; set; }

}
