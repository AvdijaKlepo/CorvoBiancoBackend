using CorvoBianco.Data;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorvoBianco.Endpoints.BookEndpoints.Book.GetBookHomePage
{
    [Microsoft.AspNetCore.Components.Route("Book")]
    public class GetBookHomePageEndpoint : MyBaseEndpoint<GetBookHomePageRequest, GetBookHomePageResponse>
    {
        private readonly DataContext _dataContext;

        public GetBookHomePageEndpoint(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetBookHomePage")]
        public override async Task<GetBookHomePageResponse> Obradi([FromQuery] GetBookHomePageRequest request,
            CancellationToken cancellationToken)
        {
            var book = await _dataContext.Books
                .OrderByDescending(x => x.Id)
                .Select(x => new BookGetBookHomePageResponse()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author.FirstName +" " + x.Author.LastName,
                    Series = x.Series.SeriesName,
                    Rating = x.Rating,
                    RatingCount = x.RatingCount,
                    BookCover = x.BookCover


                })
                .ToListAsync(cancellationToken: cancellationToken);
            return new GetBookHomePageResponse()
            {
                Books = book
            };
        }
    }
}
