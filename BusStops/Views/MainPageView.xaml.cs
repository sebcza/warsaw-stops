using System;
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
			
		}


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



//		private async void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
//		{
//
//			string uriToLaunch = @"bingmaps:?rtp=~pos.54.402520_18.581810";
//			var uri = new Uri(uriToLaunch);
//
//			// Launch the URI
//			var success = await Windows.System.Launcher.LaunchUriAsync(uri);
//		}
	}
}
