using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMeasurement.Model
{
    public class Measurement
    {
        public int ID { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public DateTime TimeStamp { get; set; }

        public Measurement() { }
        public Measurement(int id, float humidity, float pressure, float temperature, DateTime timeStamp)
            {
            ID = id;
            Humidity = humidity;
            Pressure = pressure;
            Temperature = temperature;
            TimeStamp = timeStamp;


            }
     }
}
