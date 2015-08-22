using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace openweathermap
{
    public class Location 
    {
        public string _city_name { get; set; }
        public string _city_id { get; set; }

        public Location(string city_name) : this(city_name, null) { }

        public Location(string city_name, string city_id)
        {
            _city_name = city_name;
            _city_id = city_id;

        }

    }
}
