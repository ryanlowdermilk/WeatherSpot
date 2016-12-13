using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherSpot.Model;
using Xamarin.Forms;

namespace WeatherSpot.ViewModel
{
    public class LocationDetailsViewModel : ViewModelBase
    {
        public LocationDetailsViewModel(Location location)
        {
            this.Location = location;
            Tweets = new ObservableCollection<Status>();
            GetTweetsCommand = new Command(
                async () => await GetTweets(),
                () => !IsBusy);
            GetTweetsCommand.Execute(this);            
        }

        public Command GetTweetsCommand { get; set; }

        private bool busy;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                SetProperty(ref busy, value);
                GetTweetsCommand.ChangeCanExecute();
            }
        }

        public Location Location { get; set; }

        public ObservableCollection<Status> Tweets { get; set; }

        private async Task GetTweets()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync("http://demo8782286.mockable.io/tweets/");
                    var tweets = JsonConvert.DeserializeObject<List<Tweet>>(json);

                    Tweets.Clear();
                    foreach (var tweet in tweets[0].statuses)
                        Tweets.Add(tweet);
                }
            }
            catch (Exception ex)
            {
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
