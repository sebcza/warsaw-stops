using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusStops.Adapter;
using BusStops.Models;
using Newtonsoft.Json;

namespace BusStops.Services
{
	public class BusStopService
	{
		private readonly ApiAdapter _apiAdapter;
		public BusStopService(ApiAdapter apiAdapter)
		{
			_apiAdapter = apiAdapter;
		}

		public  List<BusStopListItem> GetAllBusStops()
		{
			var httpResponse = _apiAdapter.HttpClient.GetAsync("http://bus-stop.azurewebsites.net/api/busStop").Result;
			var jsonResult = httpResponse.Content.ReadAsStringAsync().Result;
			var doo = JsonConvert.DeserializeObject<List<BusStopListItem>>(jsonResult);
			return doo;
		}

		public async Task<BusStop> GetById(int id)
		{
			var httpResponse = await _apiAdapter.HttpClient.GetAsync("http://bus-stop.azurewebsites.net/api/busStop/"+id);
			var jsonResult = await httpResponse.Content.ReadAsStringAsync();
			var doo = JsonConvert.DeserializeObject<BusStop>(jsonResult);
			return doo;
		}

		public async Task<List<BusStopListItem>> GetBusStopByName(string name)
		{
			var httpResponse = await _apiAdapter.HttpClient.GetAsync("http://bus-stop.azurewebsites.net/api/busStop?name="+name);
			var jsonResult = await httpResponse.Content.ReadAsStringAsync();
			var doo = JsonConvert.DeserializeObject<List<BusStopListItem>>(jsonResult);
			return doo;			
		} 
	}
}
