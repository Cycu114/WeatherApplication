using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{


    class OpenWeatherMapEndpoint : Endpoint
    {    

        public OpenWeatherMapEndpoint(): 
            base("a96b62e5283be49b842ec4c7b9a2d23b",
                "http://api.openweathermap.org/data",
                new Dictionary<EndpointType, string>{
                            {EndpointType.CURRENT,"weather" },
                            {EndpointType.FORECAST,"forecast"}
                },
                "2.5",
                "metric")
        {}
                     

        public string getByCityNameEndpoint(string cityName, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            return stringBuilder.ToString();
        }

        public string getByCityNameEndpoint(string cityName, string countryCode, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append(",");
            stringBuilder.Append(countryCode);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            return stringBuilder.ToString();
        }

        public string getByCityNameEndpoint(string cityName, string state, string countryCode, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append(",");
            stringBuilder.Append(state);
            stringBuilder.Append(",");
            stringBuilder.Append(countryCode);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);

            return stringBuilder.ToString();
        }
    }
}
