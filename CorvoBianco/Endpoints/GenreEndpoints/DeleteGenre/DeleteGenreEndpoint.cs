using CorvoBianco.Data;
using CorvoBianco.Endpoints.BookEndpoints.Book.DeleteBook;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;

namespace CorvoBianco.Endpoints.GenreEndpoints.DeleteGenre
{
	public class DeleteGenreEndpoint:MyBaseEndpoint<DeleteGenreRequest,DeleteGenreResponse>
	{
		private readonly DataContext _dataContext;

		public DeleteGenreEndpoint(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		[HttpDelete("DeleteGenre")]
		public override async Task<DeleteGenreResponse> Obradi([FromQuery]DeleteGenreRequest request, CancellationToken cancellationToken)
		{
			var genre = _dataContext.Genres.Find(request.GenreId); //FindAsync baca error zato je samo find :)
			if (genre != null)
			{
				_dataContext.Remove(genre);
				await _dataContext.SaveChangesAsync(cancellationToken);

				return new DeleteGenreResponse()
				{
				};
			}

			throw new Exception("No Genre was found with id = " + request.GenreId);
		}
	}
	
}
