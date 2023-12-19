using CorvoBianco.Data.Models;

namespace CorvoBianco.Endpoints.GenreEndpoints.GetGenre
{
	public class GetGenreResponse
	{
		public List<GetGenreResponseModel> Genres { get; set; } = null!;

	}
}
public class GetGenreResponseModel
{
	public int Id { get; set; }
	public string Genre { get; set; }
	public ICollection<Book>? Books { get; set; }
}
