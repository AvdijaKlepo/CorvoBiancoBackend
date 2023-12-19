using System.Diagnostics;
using CorvoBianco.Data;
using CorvoBianco.Data.Models;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.AddBookCover
{
    [Route("Book")]
    public class AddBookCoverEndpoint : MyBaseEndpoint<AddBookCoverRequest, int>
    {
        private readonly DataContext _dataContext;

        public AddBookCoverEndpoint(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        [HttpPost("AddBookCover")]
        public override async Task<int> Obradi([FromForm] AddBookCoverRequest request,
            CancellationToken cancellationToken)
        {

            Data.Models.Book? book = _dataContext.Books.FirstOrDefault(s => s.Id == request.BookId);

            if (book == null)
                throw new Exception("Non Existent Book ID");
            if (request.BookCover.Length > 3 * 1024 * 1024)
                throw new Exception("Max File Size is 3MB!");

            string ekstenzija = Path.GetExtension(request.BookCover.FileName);

            var filename = $"{Guid.NewGuid()}{ekstenzija}";

            await request.BookCover.CopyToAsync(new FileStream(Config.ImageFolder + filename, FileMode.Create), cancellationToken);
            book.BookCover = Config.ImageUrl + filename;
            await _dataContext.SaveChangesAsync(cancellationToken);

            return book.Id;


        }


    }
}
