using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using BusStops.Models;
using BusStops.Services;
using Caliburn.Micro;

namespace BusStops.ViewModels
{
	public class MainPageViewModel :Screen
	{
		private readonly INavigationService _navigationService;
		private readonly BusStopService _busStopService;
		private string _name;
		private List<BusStopListItem> _busStop = new List<BusStopListItem>();
		private bool _spinnerIsActive = false;
		private Visibility _busStopisVisibility;

		public MainPageViewModel(INavigationService navigationService, BusStopService busStopService)
		{
			_navigationService = navigationService;
			_busStopService = busStopService;
		}


		public Visibility BusStopIsVisibility
		{
			get { return _busStopisVisibility; }
			private set
			{
				_busStopisVisibility = value;
				NotifyOfPropertyChange(()=>BusStopIsVisibility);
			}
		}

		public bool SpinnerIsActive
		{
			get { return _spinnerIsActive; }
			private set
			{
				_spinnerIsActive = value;
				NotifyOfPropertyChange(()=>SpinnerIsActive);
			}
		}

		public List<BusStopListItem> BusStopsList
		{
			get { return _busStop; }
			private set { _busStop = value; NotifyOfPropertyChange(() => BusStopsList); }
		}

		private  List<BusStopListItem> GetAllBusStops()
		{
			var result =  _busStopService.GetAllBusStops();
			return result;
		}


		public string SearchTextBox 
		{
			get { return _name; }
			set
			{
				_name = value;
				SearchBusStop();
				NotifyOfPropertyChange(() => SearchTextBox);
			} 
		}

		private void SearchBusStop()
		{
			SendRequestEvent();
			_busStopService.GetBusStopByName(SearchTextBox)
					 .ContinueWith(SuccesRequestEvent);
		}

		private void SendRequestEvent()
		{
			BusStopIsVisibility = Visibility.Collapsed;
			SpinnerIsActive = true;
		}

		private void SuccesRequestEvent(Task<List<BusStopListItem>>task)
		{
			BusStopsList = task.Result;
			BusStopIsVisibility = Visibility.Visible;
			SpinnerIsActive = false;			
		}
		#region ACTIONS
		private void ClickBusStopAction(BusStopListItem busStop)
		{
			
			_navigationService.UriFor<DetailPageViewModel>()
				 .WithParam(x=>x.IdBusStop, busStop.Id)
				 .Navigate();
			var foo = busStop;
		}
		#endregion

	}
}
