using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeatherSpot.Model;
using System.Net.Http;

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
            
            try
            {
                IsBusy = true;

                using (var client = new HttpClient())
                {

                }
            }
            catch (System.Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
