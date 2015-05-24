using System.Data.Entity;

namespace WebService.Models
{
	public class BusContext : DbContext
	{
		public BusContext()
			: base("BusDBContext")
		{
			
		}
		public DbSet<BusStopEntity> BusStops { get; set; }
	}
}