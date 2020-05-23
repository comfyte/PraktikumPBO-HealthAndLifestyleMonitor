using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace HealthAndLifestyleMonitor
{
    public class Cuaca
    {
        private CuacaObject _cuacaObject;

        private IRestResponse ApiGetRequest(string path)
        {
            string apiKey = "d383e9ec57f3ab586ea47d2124225d90";

            var client = new RestClient($"http://api.openweathermap.org/data/2.5/{path}&appid={apiKey}");
            var request = new RestRequest(Method.GET);

            return client.Execute(request);
        }

        private CuacaObject FetchCuaca(string lokasi)
        {
            try
            {
                string weatherPath = $"weather?q={lokasi}&lang=id{GetUnitParameter()}";

                IRestResponse weatherResponse = ApiGetRequest(weatherPath);
                CuacaObject cuacaObject = JsonSerializer.Deserialize<CuacaObject>(weatherResponse.Content);

                string latitude = cuacaObject.coordinate.lat.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                string longitude = cuacaObject.coordinate.lon.ToString(CultureInfo.CreateSpecificCulture("en-US"));

                string uvPath = $"uvi?lat={latitude}&lon={longitude}";

                IRestResponse uvResponse = ApiGetRequest(uvPath);
                cuacaObject.UVIndex = JsonSerializer.Deserialize<UVObject>(uvResponse.Content);

                return cuacaObject;
            }
            catch
            {
                MessageBox.Show("Gagal memperoleh informasi cuaca", "Galat", MessageBoxButton.OK, MessageBoxImage.Error);
                return new CuacaObject();
            }
        }

        private bool LokasiValid(string lokasi)
        {
            CuacaObject checkObject = FetchCuaca(lokasi);

            // Check HTTP 200 OK return code
            if (checkObject.httpStatusCode == 200)
            {
                return true;
            }
            return false;
        }

        public void RefreshCuaca()
        {
            _cuacaObject = null;
        }

        public string Lokasi
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);
                return _cuacaObject.location;
            }
        }

        public string Deskripsi
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);
                return _cuacaObject.weatherInfo.description;
            }
        }

        public string Suhu
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);

                return _cuacaObject.airConditionInfo.temperature.ToString() +
                    (TemperatureUnitPref == "K" ? " " : " \xb0") + TemperatureUnitPref;
            }
        }

        public string WaktuPembaruanText
        {
            get { return "Terakhir diperbarui pada " + HLBase.WaktuSekarang; }
        }

        public string UVText
        {
            get
            {
                if (_cuacaObject == null)
                    _cuacaObject = FetchCuaca(LocationPref);

                return "Tingkat cahaya UV saat ini sekitar " + _cuacaObject.UVIndex.value.ToString();
            }
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
                    _cuacaObject = FetchCuaca(value); //fixme
                }
                else
                {
                    throw new InvalidOperationException("lokasi-tidak-valid");
                }
            }
        }

        private string GetUnitParameter()
        {
            string unitParam = "&units=";
            using (var db = new HLDatabaseContext())
            {
                switch (TemperatureUnitPref)
                {
                    case "C":
                        unitParam += "metric";
                        break;
                    case "F":
                        unitParam += "imperial";
                        break;
                    default:
                    case "K":
                        unitParam = "";
                        break;
                }
            }
            return unitParam;
        }

        public string TemperatureUnitPref
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(u => u.Name == "temperature-unit").First().StringValue;
                }
            }
            set
            {
                if (value == "C" || value == "F" || value == "K")
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(u => u.Name == "temperature-unit").First().StringValue = value;
                    }
                }
                else
                {
                    throw new InvalidOperationException("satuan-temperatur-tidak-valid");
                }
            }
        }
    }
}
