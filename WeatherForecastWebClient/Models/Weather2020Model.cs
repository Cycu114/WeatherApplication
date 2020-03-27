using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    
    [DataContract]
    class Weather2020Model
    {
        [DataMember]
        public List<Group> groups; 
    }
    [DataContract]
    class Group
    {
        [DataMember]
        public int temperatureHighCelcius { get; set; }
        [DataMember]
        public long startDate { get; set; }
    }
    /*
    [DataContract]
    class UnnamedObject
    {
        [DataMember]
        public float temperatureHighCelcius { get; set; }
        [DataMember]
        public long startDate { get; set; }
    }*/
}
