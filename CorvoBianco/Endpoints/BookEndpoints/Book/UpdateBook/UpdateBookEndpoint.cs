using CorvoBianco.Data;
using CorvoBianco.Data.Models;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.UpdateBook
{
    public class UpdateBookEndpoint : MyBaseEndpoint<UpdateBookRequest, int>
    {
        private readonly DataContext _dataContext;

        public UpdateBookEndpoint(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut("UpdateBook")]
        public override async Task<int> Obradi([FromBody] UpdateBookRequest request,
            CancellationToken cancellationToken)
        {
            var book = _dataContext.Books.FirstOrDefault(x => x.Id == request.BookId);

            if (book != null)
            {
                book.Title = request.Title;
                book.AuthorId = request.Author;
                book.SeriesId = request.SeriesId;
                book.Description = request.Description;
                book.GenreId = request.GenreId;
                book.PageCount = request.PageCount;
                book.Published = request.Published;

                await _dataContext.SaveChangesAsync(cancellationToken);


            }
            return book!.Id;
        }
    }
}
