using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class DarkSkyForecast
    {
        private DateTime dateTime;
        private float temperature;
        private float apparentTemperature;

        public DarkSkyForecast(long epochDateTime, float temperature, float apparentTemperature)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochDateTime);
            dateTime = dateTimeOffset.UtcDateTime;
            this.temperature = temperature;
            this.apparentTemperature = apparentTemperature;
        }

        public DateTime getDateTime()
        {
            return dateTime;
        }

        public float getTemperature()
        {
            return temperature;
        }

        public float getApparentTemperature()
        {
            return apparentTemperature;
        }
    }
}
