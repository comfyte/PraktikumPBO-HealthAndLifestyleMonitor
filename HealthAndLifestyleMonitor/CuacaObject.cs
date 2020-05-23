using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public class CuacaObject
    {
        public int cod { get; set; }
        public string name { get; set; }
        // WeatherArray
        public List<DetailCuacaObject> weather { get; set; }
        // Add direct accessor for [0]?
        public TemperaturCuacaObject main { get; set; }
        public KoordinatObject coord { get; set; }
        // Add empty field for uv index? public string(uvindex) function()

    }

    public class DetailCuacaObject
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }

    public class TemperaturCuacaObject
    {
        public double temp { get; set; }
    }

    public class KoordinatObject
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
}
