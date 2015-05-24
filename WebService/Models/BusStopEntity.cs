using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{

	[Table("BusStops")]
	public class BusStopEntity
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public string Direction { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public double Lat { get; set; }
		public double Long { get; set; }
	}
}