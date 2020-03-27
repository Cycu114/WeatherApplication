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
    class Weather2020Controller : Controller
    {
        private Weather2020Endpoint weather2020Endpoint;

        public Weather2020Controller() : base()
        {
            this.weather2020Endpoint = new Weather2020Endpoint();
        }


        public List<Weather2020Forecast> getForecastList(double latitude, double longitude)
        {
            List<Weather2020Forecast> forecastList = new List<Weather2020Forecast>();
            
            restClient.endpoint = weather2020Endpoint.getConditions(latitude, longitude);
            string response = restClient.makeRequest();
            


            JSONParser<List<Group>>  jsonParser = new JSONParser<List<Group>>();


            var deserialisedWeather2020Model = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (var forecastMain in deserialisedWeather2020Model)
            {
                forecastList.Add(new Weather2020Forecast(forecastMain.startDate, forecastMain.temperatureHighCelcius));
            }
            return forecastList;
        }

        public float getCurrentTemperature(double latitude, double longitude)
        {
            float temperature = 0f;

            restClient.endpoint = weather2020Endpoint.getConditions(latitude, longitude);
            string response = restClient.makeRequest();

            JSONParser<List<Group>> jsonParser = new JSONParser<List<Group>>();

            
            var deserialisedWeather2020Model = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedWeather2020Model[0].temperatureHighCelcius;

            return temperature;
        }
    }
}
