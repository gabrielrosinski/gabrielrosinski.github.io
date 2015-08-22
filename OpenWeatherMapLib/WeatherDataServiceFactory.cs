using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openweathermap
{
   static public class WeatherDataServiceFactory
    {
        static public string OPEN_WEATHER_MAP = "open_weather_map";

        public static IWeatherDataService getWeatherDataService(string return_service)
        {
            if (return_service == null)
            {
                return null;
            }
            
            if (return_service == OPEN_WEATHER_MAP)
            {
                return new OpenWeatherMap();
            }

            return null;
        }
    }
}
