using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace BusStops.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPageView : Page
	{
		public MainPageView()
		{
			this.InitializeComponent();
			Window.Current.SizeChanged += Current_SizeChanged;
			this.NavigationCacheMode = NavigationCacheMode.Required;
			Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			// TODO: Prepare page for display here.

			// TODO: If your application contains multiple pages, ensure that you are
			// handling the hardware Back button by registering for the
			// Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
			// If you are using the NavigationHelper provided by some templates,
			// this event is handled for you.
		}

		// Add this to page initializer


		void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
		{
			// Get the new view state
			// Add: using Windows.UI.ViewManagement;
			string CurrentViewState = ApplicationView.GetForCurrentView().Orientation.ToString();

			if (CurrentViewState.Equals("Landscape"))
			{
				WarsawImg.Visibility = Visibility.Collapsed;
				var margin = Margin;
				margin.Bottom = 0;
				BusStopList.Margin = margin;
			}
			else
			{
				WarsawImg.Visibility = Visibility.Visible;
				var margin = Margin;
				margin.Bottom = 98;
				BusStopList.Margin = margin;
			}
		}

		private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
		{
			MapsDirectionsTask mapsDirectionsTask = new MapsDirectionsTask();

			// You can specify a label and a geocoordinate for the end point.
			// GeoCoordinate spaceNeedleLocation = new GeoCoordinate(47.6204,-122.3493);
			// LabeledMapLocation spaceNeedleLML = new LabeledMapLocation("Space Needle", spaceNeedleLocation);

			// If you set the geocoordinate parameter to null, the label parameter is used as a search term.
			LabeledMapLocation spaceNeedleLML = new LabeledMapLocation("Space Needle", null);

			mapsDirectionsTask.End = spaceNeedleLML;

			// If mapsDirectionsTask.Start is not set, the user's current location is used as the start point.

			mapsDirectionsTask.Show();
		}
	}
}
