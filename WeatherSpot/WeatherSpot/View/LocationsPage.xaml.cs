using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSpot.ViewModel;
using Xamarin.Forms;

namespace WeatherSpot.View
{
	public partial class LocationsPage : ContentPage
	{
        LocationsViewModel vm;

		public LocationsPage ()
		{
			InitializeComponent ();

            vm = new LocationsViewModel();
            BindingContext = vm;            
		}
	}
}
