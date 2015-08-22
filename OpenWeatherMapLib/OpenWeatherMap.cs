using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace openweathermap
{
    public sealed class OpenWeatherMap : IWeatherDataService
    {
       static readonly OpenWeatherMap _instance = new OpenWeatherMap();
       public enum _doc_format { xml };
       public enum _mode_format { metric, imperial };

        public static OpenWeatherMap Instance
        {
            get
            {
                return _instance;
            }
        }

        public OpenWeatherMap()
        { 
            
        }

        public WeatherData getWeatherData(Location location)
        {

            if (location._city_id != null)
            {
                WeatherData return_weather_data_cityId =  ProcessResponse(RequestOpenWeather.BuildCompleteRequestStringForCityDataById(location._city_id,
                                                                                             _doc_format.xml.ToString(),
                                                                                             _mode_format.metric.ToString()),
                                                                                             _mode_format.metric);

                if (return_weather_data_cityId == null) throw new WeatherDataServiceException("No data was fetch by ProcessResponse function using city ID");

                return return_weather_data_cityId;

            }
            else
            {
                
                WeatherData return_city_data_city_name = ProcessResponse(RequestOpenWeather.BuildCompleteRequestStringForCityDataByName(location._city_name,
                                                                                               _doc_format.xml.ToString(),
                                                                                               _mode_format.metric.ToString()),
                                                                                               _mode_format.metric);

                if (return_city_data_city_name == null) throw new WeatherDataServiceException("No data was fetch by ProcessResponse function using city name");

                return return_city_data_city_name;
            }
        }

        public WeatherData ProcessResponse(string locationsResponse, _mode_format format)
        {
            string value = null;
            string max = null;
            string min = null;
            string unit = null;

            if (format == _mode_format.metric)
            {
                XElement processingXml = XElement.Load(locationsResponse);
                if (processingXml == null) { return null; }

                IEnumerable<XElement> country =
                from element in processingXml.Descendants("temperature")
                select element;
                foreach (XElement upa in country)
                {
                    IEnumerable<XAttribute> listOfAttributes =
                    from att in upa.Attributes()
                    select att;
                    foreach (XAttribute a in listOfAttributes)
                    {
                        switch (a.Name.ToString())
                        {
                            case "value":
                                value = a.Value;
                                break;
                            case "min":
                                min = a.Value;
                                break;
                            case "max":
                                max = a.Value;
                                break;
                            case "unit":
                                unit = a.Value;
                                break;
                        }
                    }
                   return new WeatherData(value, min, max, unit);
                }
            }

            return null;
        }


    }
}
