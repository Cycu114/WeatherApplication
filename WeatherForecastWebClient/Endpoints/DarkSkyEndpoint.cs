using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Output;

namespace WeatherForecastWebClient.Endpoints
{
    class DarkSkyEndpoint : Endpoint
    {
        public DarkSkyEndpoint() : base(
            "ce777a2ce259694cf2a573e14bd2da5c",
            "https://api.darksky.net",
             new Dictionary<EndpointType, string>{
                 { EndpointType.FORECAST, "forecast" }
                 },"",
             "si"
             ){ }

        public string getConditionsEndpoint(double cityLatitude, double cityLongitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[EndpointType.FORECAST]}");
            stringBuilder.Append($"/{apiKey}");
            stringBuilder.Append($"/{cityLatitude}");
            stringBuilder.Append($",{cityLongitude}");
            stringBuilder.Append($"?units={units}");
            return stringBuilder.ToString();
            
        }
    }
}
