using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class Weather2020Forecast
    {
        private DateTime dateTime;
        private float temperature;


        public Weather2020Forecast(long epochDateTime, float temperature)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            dateTime = dateTimeOffset.UtcDateTime;
            this.temperature = temperature;
        }

        public DateTime getDateTime()
        {
            return dateTime;
        }

        public float getTemperature()
        {
            return temperature;
        }
    }
}
