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

            LocationsListView.ItemSelected += LocationsListView_ItemSelected;        
		}

        private async void LocationsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var location = e.SelectedItem as Location;

            if (location == null)
                return;

            await Navigation.PushAsync(new LocationDetailsPage(location));

            LocationsListView.SelectedItem = null;
        }
    }
}
