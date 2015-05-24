namespace BusStops.Models
{
	public class BusStop
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public string Direction { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string Lat { get; set; }
		public string Long { get; set; }
	}
}