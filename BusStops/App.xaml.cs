using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using BusStops.Adapter;
using BusStops.Services;
using BusStops.ViewModels;
using BusStops.Views;
using Caliburn.Micro;

namespace BusStops
{
	public sealed partial class App
	{
		private WinRTContainer _container;


		public App()
		{
			InitializeComponent();
			
		}

		protected override void Configure()
		{
			Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync(); 
			
			_container = new WinRTContainer();

			_container.RegisterWinRTServices();

			_container.PerRequest<MainPageViewModel>();
			_container.PerRequest<DetailPageViewModel>();
			_container.PerRequest<BusStopService>();
			_container.PerRequest<ApiAdapter>();
		}

		protected override void PrepareViewFirst(Frame rootFrame)
		{
			_container.RegisterNavigationService(rootFrame);
		}

		protected override void OnLaunched(LaunchActivatedEventArgs args)
		{


			if (!NetworkInterface.GetIsNetworkAvailable())
			{
				DisplayRootView<NoConnectionView>();
			}
			else if (args.TileId != "App")
			{
				DisplayRootView<DetailPageView>(args);
			}
			else
			{
				DisplayRootView<MainPageView>();
			}
			


		}

		protected override object GetInstance(Type service, string key)
		{
			return _container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}
	}
}