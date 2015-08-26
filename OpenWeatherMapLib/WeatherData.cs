using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace openweathermap
{
    public class WeatherData
    {

        public string value_temperatur { get; set; }
        public string min_temperatur { get; set; }
        public string max_temperatur { get; set; }
        public string unit_used_temperatur { get; set; }

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


        public void printAllCached()
        {
            Console.WriteLine("Temperature : " + value_temperatur + " Min Temperature : "
                               + min_temperatur + " Max Temperature : " + max_temperatur
                               + " Metric used " + unit_used_temperatur);
        }

    }
}
