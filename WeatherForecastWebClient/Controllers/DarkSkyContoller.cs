using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Output;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class DarkSkyContoller : Controller
    {
        private DarkSkyEndpoint darkSkyEndpoint;

        public DarkSkyContoller() : base()
        {
            darkSkyEndpoint = new DarkSkyEndpoint();
        }

        public float getCurrentConditions(double latitude, double longitude)
        {
            float temperature = 0f;
            restClient.endpoint = darkSkyEndpoint.getConditionsEndpoint(latitude,longitude);
            string response = restClient.makeRequest();

            JSONParser<DarkSkyWheaterModel> jsonParser = new JSONParser<DarkSkyWheaterModel>();
            DarkSkyWheaterModel deserialisedDarkSkyModel = new DarkSkyWheaterModel();
            deserialisedDarkSkyModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            temperature = deserialisedDarkSkyModel.currently.temperature;
            
            return temperature;
        }

        public List<DarkSkyForecast> getForecastList(double latitude, double longitude)
        {
            List<DarkSkyForecast> forecastList = new List<DarkSkyForecast>();

            restClient.endpoint = darkSkyEndpoint.getConditionsEndpoint(latitude, longitude);
            string response = restClient.makeRequest();

            JSONParser<DarkSkyForecastModel> jsonParser = new JSONParser<DarkSkyForecastModel>();

            DarkSkyForecastModel deserialisedDarkSkyForecastModel = new DarkSkyForecastModel();
            deserialisedDarkSkyForecastModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (Data forecastMain in deserialisedDarkSkyForecastModel.hourly.data)
            {

                forecastList.Add(new DarkSkyForecast(forecastMain.time, forecastMain.temperature, forecastMain.apparentTemperature));
            }
            return forecastList;
        }
    }
}
