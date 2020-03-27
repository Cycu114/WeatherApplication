using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{   
    [DataContract]
    class DarkSkyWheaterModel
    {
        [DataMember]
        public Currently currently { get; set; }
    }
    [DataContract]
    class Currently
    {
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float pressure { get; set; }

    }
}
