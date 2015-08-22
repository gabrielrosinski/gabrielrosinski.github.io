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
                return ProcessResponse(RequestOpenWeather.BuildCompleteRequestStringForCityDataById(location._city_id,
                                                                                             _doc_format.xml.ToString(),
                                                                                             _mode_format.metric.ToString()), _mode_format.metric);
            }
            else
            {
             
                return ProcessResponse(RequestOpenWeather.BuildCompleteRequestStringForCityDataByName(location._city_name,
                                                                                               _doc_format.xml.ToString(),
                                                                                               _mode_format.metric.ToString()), _mode_format.metric);
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

        //IEnumerable<XElement> items =
        //    from el in po.Descendants("city")
        //    select el;
        //foreach (XElement prdName in items)
        //{
        //IEnumerable<XAttribute> listOfAttributes =
        //from att in prdName.Attributes()
        //select att;
        //foreach (XAttribute a in listOfAttributes)
        //    Console.WriteLine(a);
        //_city_name = prdName.FirstAttribute.Value;
        //_city_id = prdName.LastAttribute.Value;


        //IEnumerable<XElement> country =
        //from el in po.Descendants("temperature")
        //select el;
        //foreach (XElement nameCtr in country)
        //    Console.WriteLine(nameCtr.Name);
        //  _country_name = nameCtr.Value;

    }
}
