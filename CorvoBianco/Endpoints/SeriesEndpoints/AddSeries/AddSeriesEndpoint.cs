using CorvoBianco.Data;
using CorvoBianco.Data.Models;
using CorvoBianco.Helper;
using Microsoft.AspNetCore.Mvc;

namespace CorvoBianco.Endpoints.SeriesEndpoints.AddSeries
{
	public class AddSeriesEndpoint:MyBaseEndpoint<AddSeriesRequest,int>
	{
		private readonly DataContext _dataContext;

		public AddSeriesEndpoint(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpPost("AddSeries")]
		public override async Task<int> Obradi([FromBody]AddSeriesRequest request, CancellationToken cancellationToken)
		{
			var series = new Series()
			{
				SeriesName = request.SeriesName
			};
			await _dataContext.AddAsync(series);
			await _dataContext.SaveChangesAsync(cancellationToken);


			return series.Id;

		}
	}
}
