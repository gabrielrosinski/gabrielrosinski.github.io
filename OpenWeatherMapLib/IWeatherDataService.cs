﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openweathermap
{
   public interface IWeatherDataService
    {
       WeatherData getWeatherData(Location location); //throws WeatherDataServiceException
    }
}
