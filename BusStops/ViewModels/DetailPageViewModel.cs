using System;
using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.UI.StartScreen;
using Windows.UI.Xaml.Navigation;
using BusStops.Models;
using BusStops.Services;
using Caliburn.Micro;

namespace BusStops.ViewModels
{
	public class DetailPageViewModel : Screen
	{
		private readonly BusStopService _busStopService;
		private BusStop _selectedBusStop;
		private int _idBusStop;

		public LaunchActivatedEventArgs Parameter { get; set; }

		public DetailPageViewModel(BusStopService busStopService)
		{
			_busStopService = busStopService;
		}

		

		public int IdBusStop
		{
			get { return _idBusStop; }
			set
			{
				_idBusStop = value;
				NotifyOfPropertyChange(()=>IdBusStop);
			}
		}
		

		public BusStop SelectedBusStop
		{
			get { return _selectedBusStop; }
			private set
			{
				_selectedBusStop = value;
				NotifyOfPropertyChange(()=>SelectedBusStop);
			}


		}
		

		public void PinTille()
		{
			var tile = new SecondaryTile(
				"BusStop"+SelectedBusStop.Id.ToString(), 
				SelectedBusStop.Direction, 
				SelectedBusStop.Name,
				new Uri("ms-appx:///Assets/tile/BusStop170.scale-240.png"), 
				TileSize.Square150x150);

			tile.DisplayName = SelectedBusStop.Name;
			tile.Arguments = SelectedBusStop.Id.ToString();
			tile.RequestCreateAsync();
		}

		protected override void OnActivate()
		{

			base.OnActivate();
			if (IdBusStop == 0)
			{
				_busStopService.GetById(Int32.Parse(Parameter.Arguments))
					.ContinueWith(x => SelectedBusStop = x.Result);	
			}
			else
			{
				_busStopService.GetById(IdBusStop)
					.ContinueWith(x => SelectedBusStop = x.Result);
			}

		}

		protected void DeatilsNavigateBtn()
		{
			string cordinateString = SelectedBusStop.Lat + "_" + SelectedBusStop.Long;
						string uriToLaunch = @"bingmaps:?rtp=~pos."+cordinateString;
						var uri = new Uri(uriToLaunch);
			
						// Launch the URI
						Windows.System.Launcher.LaunchUriAsync(uri);
		}

	}
}