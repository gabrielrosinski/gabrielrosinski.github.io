using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace openweathermap
{
    public class WeatherData
    {

        private string value_temperatur;
        private string min_temperatur;
        private string max_temperatur;
        private string unit_used_temperatur;

        public WeatherData(string value) : this(value, null, null, null) { }
        public WeatherData(string value, string min) : this(value, min, null, null) { }
        public WeatherData(string value, string min, string max) : this(value, min, max, null) { }
        public WeatherData(string value, string min, string max, string unit)
        {
            value_temperatur = value;
            min_temperatur = min;
            max_temperatur = max;
            unit_used_temperatur = unit;
            //Console.WriteLine(value + " " + min + " " + max + " " + unit);

        }
     
    }
}
