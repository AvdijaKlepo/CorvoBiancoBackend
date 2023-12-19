using System.Diagnostics;
using System.Text.Json;
using CorvoBianco.Data;
using CorvoBianco.Data.Models;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.AddBook
{

    public class AddBookEndpoint : MyBaseEndpoint<AddBookRequest, int>
    {

        private readonly DataContext _dataContext;

        public AddBookEndpoint(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("AddBook")]
        public override async Task<int> Obradi([FromBody] AddBookRequest request, CancellationToken cancellationToken)
        {
	        var book = _dataContext.Books.Include(b => b.Author)
		        .Include(b=>b.Genre)
		        .Include(b=>b.Series)
		        .FirstOrDefault(b => b.Id == request.Id);
	        
	        book = new Data.Models.Book()
	        {
		        Title = request.Title,
				AuthorId = request.AuthorId,
		        PageCount = request.PageCount,
		        Published = request.Published,
		        Description = request.Description,
		        BookCover = Config.NoCoverImage,
		        GenreId = request.GenreId,
		        SeriesId = request.Series
	        };
	        _dataContext.Add(book);
	        await _dataContext.SaveChangesAsync(cancellationToken);


	        return book.Id;


        }
    }
}
