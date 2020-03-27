using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class WeatherbitEndpoint : Endpoint
    {
        public WeatherbitEndpoint() :
            base("a1d08ca6056042e1a514183cfeed64b3",
                "https://api.weatherbit.io/",
                new Dictionary<EndpointType, string>{
                            {EndpointType.CURRENT,"current" },
                            {EndpointType.FORECAST,"forecast/daily" }
                },
                "2.0",
                "M")
        { }
        public string getByCityNameEndpoint(string cityName, EndpointType endpointType, int days = 1)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/v{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?city=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            stringBuilder.Append("&days=");
            stringBuilder.Append(days);
            return stringBuilder.ToString();
        }
    }
}

