using System;

namespace WeatherApp.Models
{
    public class CurrentConditions
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object Precipitation { get; set; }
        public bool IsDayTime { get; set; }
        public Temprature Temprature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}
