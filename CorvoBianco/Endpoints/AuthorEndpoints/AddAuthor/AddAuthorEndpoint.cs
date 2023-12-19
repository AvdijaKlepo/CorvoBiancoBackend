using CorvoBianco.Data;
using CorvoBianco.Data.Models;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;

namespace CorvoBianco.Endpoints.AuthorEndpoints.AddAuthor
{
	public class AddAuthorEndpoint:MyBaseEndpoint<AddAuthorRequest,int>
	{
		private readonly DataContext _dataContext;

		public AddAuthorEndpoint(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpPost("AddAuthor")]
		public override async Task<int> Obradi([FromBody] AddAuthorRequest request, CancellationToken cancellationToken)
		{
			var author = new Author()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Born = request.Born,
				Bio = request.Bio,
				ProfilePicture = Config.NoAuthorImage
			};
			await _dataContext.AddAsync(author);
			await _dataContext.SaveChangesAsync(cancellationToken);


			return author.Id;
		}
	}
}
