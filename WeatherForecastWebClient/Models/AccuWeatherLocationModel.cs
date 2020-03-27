using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class AccuWeatherLocationModel
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public GeoPosition GeoPosition;
    }
    [DataContract]
    class GeoPosition
    {
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }
    }
}
