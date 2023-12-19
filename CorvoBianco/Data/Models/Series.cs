using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorvoBianco.Data.Models
{
	public class Series
	{
		[Key]
		public int Id { get; set; }

		public string SeriesName { get; set; }
		public int NumberOfBooks { get; set; }
		[InverseProperty(nameof(Book.Series))]
		public ICollection<Book>? Books { get; set; }
	}
}
