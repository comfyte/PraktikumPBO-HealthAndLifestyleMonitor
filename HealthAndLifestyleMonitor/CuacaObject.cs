using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HealthAndLifestyleMonitor
{
    public class CuacaObject
    {
        [JsonPropertyName("cod")]
        public int httpStatusCode { get; set; } = 0;

        [JsonPropertyName("name")]
        public string location { get; set; } = "Error";

        [JsonPropertyName("weather")]
        public List<DetailCuacaObject> weatherInfoList { get; set; } = new List<DetailCuacaObject> { new DetailCuacaObject() };
        public DetailCuacaObject weatherInfo
        {
            get { return weatherInfoList[0]; }
        }

        [JsonPropertyName("main")]
        public KondisiUdaraObject airConditionInfo { get; set; } = new KondisiUdaraObject();

        [JsonPropertyName("coord")]
        public KoordinatObject coordinate { get; set; } = new KoordinatObject();

        [JsonPropertyName("dt")]
        public int updateTimeUnixUtc { get; set; }
        public string updateTime
        {
            get { return DateTimeOffset.FromUnixTimeSeconds(updateTimeUnixUtc).ToLocalTime().ToString("HH:mm"); }
        }

        public UVObject UVIndex { get; set; } = new UVObject();
    }

    public class DetailCuacaObject
    {
        [JsonPropertyName("id")]
        public int weatherCode { get; set; } = 0;

        public string description { get; set; } = "error";
    }

    public class KondisiUdaraObject
    {
        [JsonPropertyName("temp")]
        public double temperature { get; set; } = 0;
    }

    public class KoordinatObject
    {
        public double lon { get; set; } = 0;
        public double lat { get; set; } = 0;
    }

    public class UVObject
    {
        public double value { get; set; } = 0;
    }
}
