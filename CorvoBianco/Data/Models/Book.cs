using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorvoBianco.Data.Models
{
	[Table("Book")]
	public class Book
	{
		[Key]public int Id { get; set; }
		public string Title { get; set; } = null!;
		[ForeignKey(nameof(Author))]
		[InverseProperty("Books")]
		public int AuthorId { get; set; }

		public  Author Author { get; set; }
		public float? Rating { get; set; } = 0;
		public float? RatingCount { get; set; } = 0;
		public string Description { get; set; } = null!;
		public int PageCount { get; set; } = 0;
		public DateTime Published { get; set; }
		public string? BookCover { get; set; }
		[ForeignKey(nameof(Genre))]
		[InverseProperty("Books")]
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		[ForeignKey(nameof(Series))]
		[InverseProperty("Books")]
		public int SeriesId { get; set; }
		public Series Series { get; set; }


	}
}
