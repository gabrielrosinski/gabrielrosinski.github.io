using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openweathermap;
using System.Xml;

namespace OpenWeatherMapUnitTest
{
    [TestClass]
    public class UnitTestAllFunctions
    {
        [TestMethod]
        public void TestMethod1()
        {

            Location newlocation = new Location("Haim Michael !");

            try
            {
                
                IWeatherDataService open_map_weather = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            }
            catch (Exception e)
            {

                Assert.AreEqual(e.Message,"No data was fetch by ProcessResponse function using city ID");

            }
        }
    }
}
