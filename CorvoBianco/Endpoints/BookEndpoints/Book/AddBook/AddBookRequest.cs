using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CorvoBianco.Data.Models;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.AddBook
{
    public class AddBookRequest
    {
	    public int Id { get; set; }
        public string Title { get; set; } = null!;

        public int AuthorId { get; set; }
        public int Series { get; set; } 
        public float? Rating { get; set; } = 0;
        public float? RatingCount { get; set; } = 0;
        public string Description { get; set; } = null!;
        public int GenreId { get; set; }
        public int PageCount { get; set; } = 0;
        public DateTime Published { get; set; }


    }
}
