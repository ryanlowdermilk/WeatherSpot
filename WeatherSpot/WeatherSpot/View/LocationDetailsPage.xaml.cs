using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSpot.Model;
using Xamarin.Forms;

namespace WeatherSpot.View
{
	public partial class LocationDetailsPage : ContentPage
	{
        Location location;

        public LocationDetailsPage(Location location)
        {
            InitializeComponent();
            this.location = location;
            this.BindingContext = this.location;
        }
    }
}
