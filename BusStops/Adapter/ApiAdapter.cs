using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BusStops.Adapter
{
	public class ApiAdapter
	{
		public HttpClient HttpClient { get; set; }
		private readonly Uri _baseUri = new Uri("http://bus-stop.azurewebsites.net/api/");
		public HttpRequestMessage HttpRequestMessage { get; private set; }

		public ApiAdapter()
		{
			HttpClient = new HttpClient {BaseAddress = _baseUri};
			HttpRequestMessage = new HttpRequestMessage();
			HttpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("json/application"));
		}



	}
}
