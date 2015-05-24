using Caliburn.Micro;

namespace BusStops.ViewModels
{
	public class MainPageViewModel : PropertyChangedBase
	{
		private INavigationService _navigationService;
		private string _name="Hahah";

		public MainPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}


		public string Name 
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyOfPropertyChange(() => Name);
			} 
		}
	}
}
