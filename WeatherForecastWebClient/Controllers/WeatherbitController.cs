using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;
using WeatherForecastWebClient.WeatherModel;
using WeatherForecastWebClient.Output;
using WeatherForecastWebClient.Models;

namespace WeatherForecastWebClient.Controllers
{
    class WeatherbitController : Controller
    {
        private WeatherbitEndpoint WeatherbitEndpoint;

        public WeatherbitController() : base()
        {
            this.WeatherbitEndpoint = new WeatherbitEndpoint();

        }

        public float getCurrentTemperature(string city, EndpointType endpointType)
        {
            float temperature = 0f;
            Out output = new Out();
            restClient.endpoint = WeatherbitEndpoint.getByCityNameEndpoint(city, endpointType);
            string response = restClient.makeRequest();

            JSONParser<WeatherbitModel> jsonParser = new JSONParser<WeatherbitModel>();

            WeatherbitModel deserialisedWeatherbitModel = new WeatherbitModel();
            deserialisedWeatherbitModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedWeatherbitModel.data[0].temp;
            /*
            output.outputToConsole($"wynik - {deserialisedWeatherbitModel.data[0].temp}");
            foreach (ApiData dataWeb in deserialisedWeatherbitModel.data)
            {

                output.outputToConsole($"wynik2 - {dataWeb.temp}");
            }*/

            return temperature;
        }

        public WeatherbitModel getForecastList(string city, EndpointType endpoint, int days)
        {


            restClient.endpoint = WeatherbitEndpoint.getByCityNameEndpoint(city, endpoint, days);
            string response = restClient.makeRequest();

            JSONParser<WeatherbitModel> jsonParser = new JSONParser<WeatherbitModel>();

            WeatherbitModel deserialisedWeatherbitMapModel = new WeatherbitModel();
            deserialisedWeatherbitMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            WeatherbitModel forecastList = new WeatherbitModel();
            foreach (ApiData forecastMain in deserialisedWeatherbitMapModel.data)
            {
                forecastList.Add(forecastMain);
            }
            return forecastList;
        }
    }
}
