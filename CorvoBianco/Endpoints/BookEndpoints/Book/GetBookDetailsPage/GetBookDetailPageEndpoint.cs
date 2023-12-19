using System.Diagnostics;
using CorvoBianco.Data;
using CorvoBianco.Data.Models;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.GetBookDetailsPage
{
    [Microsoft.AspNetCore.Components.Route("Book")]
    public class GetBookDetailPageEndpoint : MyBaseEndpoint<int, GetBookDetailPageResponse>
    {
        private readonly DataContext _dataContext;

        public GetBookDetailPageEndpoint(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet("GetBookDetails{id}")]
        public override async Task<GetBookDetailPageResponse> Obradi(int id, CancellationToken cancellationToken)
        {
            var bookDetails = await _dataContext.Books.Select(x => new GetBookDetailPageResponse()
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author.FirstName + " " + x.Author.LastName,
                Rating = x.Rating,
                RatingCount = x.RatingCount,
                Genres = x.Genre.GenreName,
                Description = x.Description,
                PageCount = x.PageCount,
                Series = x.Series.SeriesName,
                BookCover = x.BookCover,
                Published = x.Published
            })
                .SingleAsync(x => x.Id == id, cancellationToken: cancellationToken);

            return bookDetails;
        }
    }
}
