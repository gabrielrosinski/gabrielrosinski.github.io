using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace openweathermap
{
    class WeatherDataServiceException : Exception
    {
        public WeatherDataServiceException(string message)
        : base(message) { }
    }
}
