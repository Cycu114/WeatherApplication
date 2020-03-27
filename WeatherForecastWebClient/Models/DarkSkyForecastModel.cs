using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class DarkSkyForecastModel
    {  
       
        [DataMember]
        public Hourly hourly { get; set; }
    }
    [DataContract]
    class Hourly
    {
        [DataMember]
        public List<Data> data;
    }
    [DataContract] 
    class Data  
    {
        [DataMember]
        public long time { get; set; }
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float apparentTemperature { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float pressure { get; set; }
        
    }
}
