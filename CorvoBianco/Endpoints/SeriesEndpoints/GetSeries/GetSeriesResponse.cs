using CorvoBianco.Data.Models;

namespace CorvoBianco.Endpoints.SeriesEndpoints.GetSeries
{
	public class GetSeriesResponse
	{
		public List<GetSeriesResponseModel> Series { get; set; }

	}
}
public class GetSeriesResponseModel
{
	public int Id { get; set; }
	public string SeriesName { get; set; }
	public int NumberOfBooks { get; set; }
	public ICollection<Book> Books { get; set; }

}
