using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSpot.Model;
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
            NavigationPage.SetHasNavigationBar(this, false);

            vm = new LocationsViewModel();
            BindingContext = vm;

            LocationsView.ItemSelected += LocationsView_ItemSelected;        
		}

        private async void LocationsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var location = e.SelectedItem as Location;

            if (location == null)
                return;

            await Navigation.PushAsync(new LocationDetailsPage(location));

            e.SelectedItem == null;
        }
    }
}
