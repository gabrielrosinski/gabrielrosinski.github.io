﻿using System;
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
        }
    }
}



///////Things to do
//1. it need to excepts location                                  - done
//2. add unit test

//make it a package separately from the test program
//make git hub account and commit it                              - done
//make git pages
//make the stupid video

