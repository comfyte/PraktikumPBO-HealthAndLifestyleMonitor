using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace HealthAndLifestyleMonitor
{
    public class Cuaca
    {
        private string _apiKey = "d383e9ec57f3ab586ea47d2124225d90";

        private CuacaObject _cuacaObject;

        public string Lokasi
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = GetCuaca(LocationPref);
                return _cuacaObject.name;
            }
        }

        private CuacaObject GetCuaca(string lokasi)
        {
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={lokasi}&lang=id&appid={_apiKey}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            return JsonSerializer.Deserialize<CuacaObject>(response.Content);
        }

        private bool LokasiValid(string lokasi)
        {
            CuacaObject checkObject = GetCuaca(lokasi);

            // Check HTTP 200 OK return code
            if (checkObject.cod == 200)
            {
                return true;
            }
            return false;
        }

        public string LocationPref
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(w => w.Name == "weather-location").First().StringValue;
                }
            }
            set
            {
                // Don't forget to trim whitespaces, probably in code-behind, automatically change textbox value to trimmed one
                if (LokasiValid(value))
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(w => w.Name == "weather-location").First().StringValue = value;
                    }
                    _cuacaObject = GetCuaca(value); //fixme
                }
                else
                {
                    throw new InvalidOperationException("lokasi-tidak-valid");
                }
            }
        }
    }
}
