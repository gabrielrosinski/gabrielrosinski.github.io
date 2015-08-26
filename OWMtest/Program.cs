using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using openweathermap;

namespace openweathermaptest
{
    class Program
    {
        static void Main(string[] args)
        {
            Location newlocation = new Location("Israel");
            IWeatherDataService open_map_weather = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);

            WeatherData opachki = open_map_weather.getWeatherData(newlocation);
            opachki.printAllCached();
            Console.WriteLine(" Max temp " + opachki.max_temperatur + " Min temp " + opachki.min_temperatur + " temp " + opachki.value_temperatur);
        }
    }
}

