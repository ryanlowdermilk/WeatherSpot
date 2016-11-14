using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeatherSpot.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WeatherSpot.ViewModel
{
    public class LocationsViewModel : INotifyPropertyChanged
    {
        public LocationsViewModel()
        {
            Locations = new ObservableCollection<Location>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private bool busy;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Location> Locations { get; set; }

        private async Task GetLocations()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync("https://demo8782286.mockable.io/locations");
                    var locations = JsonConvert.DeserializeObject<List<Location>>(json);
                    Locations.Clear();
                    foreach (var item in locations)
                        Locations.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }

    }
}
