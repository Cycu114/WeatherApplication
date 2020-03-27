using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.ForecastModel
{
    [DataContract]
    class OpenWeatherMapForecastModel
    {
        [DataMember]
        public List<UnnamedObject> list { get; set; }
    }
    [DataContract]
    class UnnamedObject
    {
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public long dt { get; set; }
    }

    [DataContract]
    class Main
    {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public float feels_like { get; set; }
        [DataMember]
        public float temp_min { get; set; }
        [DataMember]
        public float temp_max { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float sea_level { get; set; }
        [DataMember]
        public float grnd_level { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float temp_kf { get; set; }
    }
}
