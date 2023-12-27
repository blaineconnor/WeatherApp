using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string Base_Url = "http://dataservice.accuweather.com/";
        public const string AutoComplete_EndPoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language=tr-tr";
        public const string CurrentConditions_EndPoint = "currentconditions/v1/{0}?apikey={1}&language=tr-tr";
        public const string Api_Key = "6w23GcyYBsQB89okHiYn6LjNlnGbXk50";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string url = Base_Url + string.Format(AutoComplete_EndPoint, Api_Key, query);
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            string url = Base_Url + string.Format(CurrentConditions_EndPoint,cityKey,Api_Key );
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }
            return currentConditions;

        }
    }
}
