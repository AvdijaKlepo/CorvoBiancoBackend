using CorvoBianco.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CorvoBianco.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Series> Series { get; set; }
		public DataContext(DbContextOptions options) : base(options)
		{
			
		}

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		
			base.OnModelCreating(modelBuilder);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}
	}
}
