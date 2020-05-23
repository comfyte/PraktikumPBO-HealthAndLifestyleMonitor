using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HealthAndLifestyleMonitor
{
    public class CuacaObject
    {
        [JsonPropertyName("cod")]
        public int httpStatusCode { get; set; } = -1;

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

        public UVParentObject uvIndex { get; set; } = new UVParentObject();
    }

    public class DetailCuacaObject
    {
        [JsonPropertyName("id")]
        public int weatherCode { get; set; } = -1;

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

    public class UVParentObject
    {
        public UVObject result { get; set; } = new UVObject();
    }

    public class UVObject
    {
        public double uv { get; set; } = -1;

        [JsonPropertyName("sun_info")]
        public InfoMatahariObject sunInfo { get; set; } = new InfoMatahariObject();
    }

    public class InfoMatahariObject
    {
        [JsonPropertyName("sun_times")]
        public WaktuMatahariObject sunTimes { get; set; } = new WaktuMatahariObject();
    }

    public class WaktuMatahariObject
    {
        [JsonPropertyName("dawn")]
        public DateTime dawnUtc { get; set; }
        public DateTime dawnLocalTime
        {
            get { return dawnUtc.ToLocalTime(); }
        }

        [JsonPropertyName("dusk")]
        public DateTime duskUtc { get; set; }
        public DateTime duskLocalTime
        {
            get { return duskUtc.ToLocalTime(); }
        }
    }
}
