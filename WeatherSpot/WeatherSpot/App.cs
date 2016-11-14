using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherSpot.View;
using Xamarin.Forms;

namespace WeatherSpot
{
	public class App : Application
	{
		public App ()
		{
            var content = new LocationsPage();
            MainPage = new NavigationPage(content);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
