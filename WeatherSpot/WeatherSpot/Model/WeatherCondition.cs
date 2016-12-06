namespace WeatherSpot.Model
{
    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class WeatherCondition
    {
        public string LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }

        public string WeatherIconUrl
        {
            get {
                var padded = WeatherIcon.ToString().PadLeft(2, '0');
                return $"http://apidev.accuweather.com/developers/Media/Default/WeatherIcons/{padded}-s.png";
            }            
        }

        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}
