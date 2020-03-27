using System;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.WebClient;
using WeatherForecastWebClient.Output;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using WeatherForecastWebClient.WeatherModel;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.Controllers;
using WeatherForecastWebClient.POCO;
using WeatherForecastWebClient.Models;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = String.Empty;
            /*
            //OpenWeatherMap
            openWeatherMapCurrentAPI();
            openWeatherMapForecastAPI();

            //Accuweather
            accuweatherCurrentConditionsAPI();
            accuweatherForecastAPI();

            //DarkSky
            darkSkyWheaterCurrentAPI();
            darkSkyWheaterForecastAPI();

            //WetherBit
            //weatherbitCurrentAPI();
            // weatherbitForecastAPI();
            */
            //Weather2020
            weather2020CurrentApi();
            weather2020ForecastApi();

            Console.ReadKey();

        }

        static void openWeatherMapCurrentAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("**** Open Weather Map Current Weather *****");

            string cityName = "Valletta";
            output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName,EndpointType.CURRENT)}");

            cityName = "London";
            output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");
        }

        static void openWeatherMapForecastAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("**** Open Weather Map Forecast *****");

            string cityName = "Valletta";

            output.outputToConsole($"Forecast weather for: {cityName}");

            foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecastList(cityName,EndpointType.FORECAST))
            {          
                output.outputToConsole($"Date/Time: {forecast.dateTime} Temperature: {forecast.temperature}");
            }
        }

        static void accuweatherCurrentConditionsAPI()
        {
            Out output = new Out();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            output.outputToConsole("***** Accuweather Current Conditions *****");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature for {cityName}: {accuweatherController.getCurrentWeather(cityName)}");
        }

        static void accuweatherForecastAPI()
        {
            Out output = new Out();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            output.outputToConsole("***** Accuweather Forecast *****");

            string cityName = "Valletta";

            foreach (AccuWeatherForecast forecast in accuweatherController.getForecast(cityName))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }
        static void darkSkyWheaterCurrentAPI()
        {
            Out output = new Out();
            DarkSkyContoller darkSkyController = new DarkSkyContoller();
            AccuWeatherController accuweatherController = new AccuWeatherController();

            output.outputToConsole("***** DarkSky Curent Wheather *****");

            string cityName = "Valletta";
            double latitude = accuweatherController.getLocationLatitude(cityName);
            double longitude = accuweatherController.getLocationLongitude(cityName);


            output.outputToConsole($"Temperature for {cityName}: {darkSkyController.getCurrentConditions(latitude,longitude)}");
        }
        static void darkSkyWheaterForecastAPI()
        {
            Out output = new Out();

            DarkSkyContoller darkSkyController = new DarkSkyContoller();
            AccuWeatherController accuWeatherController = new AccuWeatherController();
            output.outputToConsole("***** DarkSky Forecast Wheater *****");

            string cityName = "Valletta";
            //output.outputToConsole($"{darkSkyController.getForecastList(1,1)}");
            double latitude = accuWeatherController.getLocationLatitude(cityName);
            double longitude = accuWeatherController.getLocationLongitude(cityName);

            foreach (DarkSkyForecast forecast in darkSkyController.getForecastList(latitude, longitude))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Temperature: {forecast.getTemperature()} Apparent Temperature: {forecast.getApparentTemperature()}");
             }
        }

        static void weather2020CurrentApi()
        {
            Out output = new Out();

            var weather2020Controller = new Weather2020Controller();
            //AccuWeatherController accuWeatherController = new AccuWeatherController();
            output.outputToConsole("***** Weather2020 Current Wheater *****");

            string cityName = "Valletta";
            //output.outputToConsole($"{darkSkyController.getForecastList(1,1)}");
            double latitude = 39.09972;
            double longitude = -94.57856;

            output.outputToConsole($"Temperature for {cityName}: {weather2020Controller.getCurrentTemperature(latitude, longitude)}");
        }
        static void weather2020ForecastApi()
        {
            Out output = new Out();

            Weather2020Controller weather2020Controller = new Weather2020Controller();
            //AccuWeatherController accuWeatherController = new AccuWeatherController();
            output.outputToConsole("***** Weather2020 Forecast Wheater *****");

            string cityName = "Valletta";
            //output.outputToConsole($"{darkSkyController.getForecastList(1,1)}");
            double latitude = 39.09972;
            double longitude = -94.57856;

            foreach (Weather2020Forecast forecast in weather2020Controller.getForecastList(latitude, longitude))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Temperature: {forecast.getTemperature()}");
            }
        }
        static void weatherbitCurrentAPI()
        {
            Out output = new Out();

            WeatherbitController weatherbitController = new WeatherbitController();

            output.outputToConsole("***** Weatherbit Current Weather *****");

            string cityName = "Valletta";

            output.outputToConsole($"Current temperature for {cityName}: {weatherbitController.getCurrentTemperature(cityName, EndpointType.CURRENT)} ");

        }

        static void weatherbitForecastAPI()
        {
            Out output = new Out();

            WeatherbitController weatherbitController = new WeatherbitController();

            output.outputToConsole("***** Weatherbit Forecast *****");

            string cityName = "Valletta";


            foreach (ApiData forecast in weatherbitController.getForecastList(cityName, EndpointType.FORECAST, 5).data)
            {
                output.outputToConsole($"Location: {cityName}, Date: {forecast.datetime}, Temp: {forecast.temp}");
            }
        }

    }
}
