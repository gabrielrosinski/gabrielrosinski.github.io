using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace openweathermap
{
    public class RequestOpenWeather
    {
        public static string BuildCompleteRequestStringForCityDataByName(string city_name, string format, string mode)
        {
            string UrlRequest_cityName = "http://api.openweathermap.org/data/2.5/weather?q=" +
                                          city_name +
                                         "&mode=" +
                                          format +
                                         "&units=" +
                                          mode;
            return (UrlRequest_cityName);
        }

        public static string BuildCompleteRequestStringForCityDataById(string city_id, string format, string mode)
        {
            string UrlRequest_cityId = "http://api.openweathermap.org/data/2.5/weather?id=" +
                                        city_id +
                                       "&mode=" +
                                        format +
                                       "&units=" +
                                        mode;
            return (UrlRequest_cityId);
        }

        public static XmlDocument MakeXmlRequestWithCompleteString(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Read();
                return null;
            }
        }
    }
}
