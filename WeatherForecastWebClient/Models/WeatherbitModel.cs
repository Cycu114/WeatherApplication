using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace WeatherForecastWebClient.Models
{

    [DataContract]
    class WeatherbitModel
    {
        
        [DataMember]
        public List<ApiData> data { get; set; }
        
        public WeatherbitModel()
        {
            data = new List<ApiData>();
        }
        public void Add(ApiData forecastMain)
        {
            this.data.Add(forecastMain);
        }

    }

    [DataContract]
    class ApiData
    {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public string datetime { get; set; }
    }

}
