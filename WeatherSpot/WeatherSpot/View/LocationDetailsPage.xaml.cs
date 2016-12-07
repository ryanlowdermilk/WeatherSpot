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
	public partial class LocationDetailsPage : ContentPage
	{
        public LocationDetailsPage(Location location)
        {
            InitializeComponent();
            LocationDetailsViewModel vm = new LocationDetailsViewModel(location);
            this.BindingContext = vm;
        }
    }
}
